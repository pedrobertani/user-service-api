using Application.DTOs;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MyApp.Tests.Application
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            // Configurando o mock do repositório
            _userRepositoryMock = new Mock<IUserRepository>();

            // Configurando o AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>().ReverseMap();
            });
            _mapper = config.CreateMapper();

            // Instanciando o serviço a ser testado
            _userService = new UserService(_userRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task CreateUpdateAsync_ShouldCreateNewUser_WhenUserDoesNotExist()
        {
            // Arrange: Simula que o usuário não existe no repositório
            _userRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((User)null);

            var userDto = new UserDto
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Password = "SecurePassword123" 
            };

            var user = _mapper.Map<User>(userDto);

            // Simula a criação de um novo usuário no repositório
            _userRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<User>())).ReturnsAsync(user);

            // Act: Chama o método CreateUpdateAsync
            var result = await _userService.CreateUpdateAsync(userDto);

            // Assert: Verifica se o método CreateAsync foi chamado e se o resultado não é nulo
            _userRepositoryMock.Verify(repo => repo.CreateAsync(It.IsAny<User>()), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(userDto.Email, result.Email);
        }


        [Fact]
        public async Task Get_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var userDto = new UserDto
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Password = "SecurePassword123"
            };
            var user = _mapper.Map<User>(userDto);

            _userRepositoryMock.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(user);

            // Act
            var result = await _userService.Get(userDto.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userDto.Email, result.Email);
            _userRepositoryMock.Verify(repo => repo.Get(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllUsers()
        {
            // Arrange
            var userDtos = new List<UserDto>
            {
                new UserDto { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Password = "SecurePassword123" },
                new UserDto { Id = 2, Name = "Jane Doe", Email = "jane.doe@example.com", Password = "AnotherPassword123" }
            };
            var users = _mapper.Map<List<User>>(userDtos);

            _userRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(users);

            // Act
            var result = await _userService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userDtos.Count, result.Count);
            _userRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetByEmail_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var userDto = new UserDto
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Password = "SecurePassword123"
            };
            var user = _mapper.Map<User>(userDto);

            _userRepositoryMock.Setup(repo => repo.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);

            // Act
            var result = await _userService.GetByEmail(userDto.Email);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userDto.Email, result.Email);
            _userRepositoryMock.Verify(repo => repo.GetByEmailAsync(It.IsAny<string>()), Times.Once);
        }


        [Fact]
        public async Task Remove_ShouldCallDeleteAsync_WhenUserExists()
        {
            // Arrange
            var userId = 1;

            // Act
            await _userService.Remove(userId);

            // Assert
            _userRepositoryMock.Verify(repo => repo.DeleteAsync(userId), Times.Once);
        }

        [Fact]
        public async Task SearchByEmail_ShouldReturnMatchingUsers()
        {
            // Arrange
            var userDtos = new List<UserDto>
            {
                new UserDto { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Password = "SecurePassword123" },
                new UserDto { Id = 2, Name = "Jane Doe", Email = "jane.doe@example.com", Password = "AnotherPassword123" }
            };
            var users = _mapper.Map<List<User>>(userDtos);

            _userRepositoryMock.Setup(repo => repo.SearchByEmailAsync(It.IsAny<string>())).ReturnsAsync(users);

            // Act
            var result = await _userService.SearchByEmail("example.com");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userDtos.Count, result.Count);
            _userRepositoryMock.Verify(repo => repo.SearchByEmailAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task SearchByName_ShouldReturnMatchingUsers()
        {
            // Arrange
            var userDtos = new List<UserDto>
    {
        new UserDto { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Password = "SecurePassword123" },
        new UserDto { Id = 2, Name = "Jane Doe", Email = "jane.doe@example.com", Password = "AnotherPassword123" }
    };
            var users = _mapper.Map<List<User>>(userDtos);

            _userRepositoryMock.Setup(repo => repo.SearchByNameAsync(It.IsAny<string>())).ReturnsAsync(users);

            // Act
            var result = await _userService.SearchByName("Doe");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userDtos.Count, result.Count);
            _userRepositoryMock.Verify(repo => repo.SearchByNameAsync(It.IsAny<string>()), Times.Once);
        }

    }
}

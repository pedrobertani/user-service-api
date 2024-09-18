using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateUpdateAsync(UserDto userDto)
        {
            var userExists = await _userRepository.Get(userDto.Id);

            var userEntity = _mapper.Map<User>(userDto);

            if (userExists != null)
            {
                userEntity.Validate();
                var update = await _userRepository.UpdateAsync(userEntity);
                return _mapper.Map<UserDto>(update);
            }
            else
            {
                userEntity.Validate();
                var created = await _userRepository.CreateAsync(userEntity);
                return _mapper.Map<UserDto>(created);
            }
        }

        public async Task<UserDto> Get(int id)
        {
            var user = await _userRepository.Get(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAll()
        {
            var allUsers = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(allUsers);
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return _mapper.Map<UserDto>(user);
        }

        public async Task Remove(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<List<UserDto>> SearchByEmail(string email)
        {
            var users = await _userRepository.SearchByEmailAsync(email);
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<List<UserDto>> SearchByName(string name)
        {
            var users = await _userRepository.SearchByNameAsync(name);
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}

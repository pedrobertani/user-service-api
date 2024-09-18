using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUpdateAsync(UserDto userDto);
        Task Remove(int id);
        Task<UserDto> Get(int id);
        Task<List<UserDto>> GetAll();
        Task<List<UserDto>> SearchByName(string name);
        Task<List<UserDto>> SearchByEmail(string email);
        Task<UserDto> GetByEmail(string email);
    }
}

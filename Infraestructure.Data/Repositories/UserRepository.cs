using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;

namespace Infraestructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ManagerContext _context;

        public UserRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _context.Users
                                     .Where(x => x.Email.ToLower() == email.ToLower())
                                     .AsNoTracking()
                                     .ToListAsync();

            return user.FirstOrDefault();
        }

        public async Task<List<User>> SearchByEmailAsync(string email)  
        {
            var allUsers = await _context.Users
                                         .Where(x => x.Email.ToLower().Contains(email.ToLower()))  
                                         .AsNoTracking()
                                         .ToListAsync();
            return allUsers;
        }

        public async Task<List<User>> SearchByNameAsync(string name)  
        {
            var allUsers = await _context.Users
                                         .Where(x => x.Name.ToLower().Contains(name.ToLower()))  
                                         .AsNoTracking()
                                         .ToListAsync();
            return allUsers;
        }
    }
}

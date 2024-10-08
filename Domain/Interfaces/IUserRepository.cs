﻿using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAsync(string email);

        Task<List<User>> SearchByEmailAsync(string email);

        Task<List<User>> SearchByNameAsync(string name);
    }
}

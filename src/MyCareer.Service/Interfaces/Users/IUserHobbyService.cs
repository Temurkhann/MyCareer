﻿using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Users
{
    public interface IUserHobbyService
    {
        ValueTask<IEnumerable<UserHobby>> GetAll(PaginationParams @params, Expression<Func<UserHobby, bool>> expression = null);
        ValueTask<UserHobby> GetAsync(Expression<Func<UserHobby, bool>> expression);
        ValueTask<UserHobby> CreateAsync(UserHobbyForCreationDTO userHobbyForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<UserHobby> UpdateAsync(int id, UserHobbyForCreationDTO userHobbyForCreation);
    }
}

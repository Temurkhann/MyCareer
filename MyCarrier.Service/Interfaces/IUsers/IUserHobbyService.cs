using MyCarrier.Domain.Configurations;
using MyCarrier.Domain.Entities.Users;
using MyCarrier.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.Interfaces.Users
{
    internal interface IUserHobbyService
    {
        IQueryable<UserHobby> GetAll(PaginationParams @params, Expression<Func<UserHobby, bool>> expression = null);
        ValueTask<UserHobby> GetAsync(Expression<Func<UserHobby, bool>> expression);
        ValueTask<UserHobby> CreateAsync(UserHobbyForCreationDTO userHobbyForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        UserHobby Update(int Id, UserHobbyForCreationDTO userHobbyForCreation);
    }
}

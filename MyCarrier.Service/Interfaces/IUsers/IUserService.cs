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
    public interface IUserService
    {
        IQueryable<User> GetAll(PaginationParams @params, Expression<Func<User, bool>> expression = null);
        ValueTask<User> GetAsync(Expression<Func<User, bool>> expression);
        ValueTask<User> CreateAsync(UserForCreationDTO userForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        User Update(int Id, UserForCreationDTO userForCreation);
    }
}

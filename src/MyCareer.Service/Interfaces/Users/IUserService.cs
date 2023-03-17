using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Users;

namespace MyCareer.Service.Interfaces.Users
{
    public interface IUserService
    {
        ValueTask<IQueryable<User>> GetAll(PaginationParams @params, Expression<Func<User, bool>> expression = null);
        ValueTask<User> GetAsync(Expression<Func<User, bool>> expression);
        ValueTask<User> CreateAsync(UserForCreationDTO userForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<User> Update(int Id, UserForCreationDTO userForCreation);
    }
}

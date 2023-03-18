using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Hobbies;
using MyCareer.Service.DTOs.Users;

namespace MyCareer.Service.Interfaces.Users
{
    public interface IUserHobbyService
    {
        ValueTask<IEnumerable<UserHobby>> GetAll(PaginationParams @params, Expression<Func<UserHobby, bool>> expression = null);
        ValueTask<UserHobby> GetAsync(Expression<Func<UserHobby, bool>> expression);
        ValueTask<UserHobby> CreateAsync(UserHobbyForCreationDTO userHobbyForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<UserHobby> Update(int Id, UserHobbyForCreationDTO userHobbyForCreation);
    }
}

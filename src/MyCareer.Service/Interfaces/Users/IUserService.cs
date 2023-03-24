using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Users
{
    public interface IUserService
    {
        ValueTask<IEnumerable<UserForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<User, bool>> expression = null);
        ValueTask<UserForViewDTO> GetAsync(Expression<Func<User, bool>> expression);
        ValueTask<UserForViewDTO> CreateAsync(UserForCreationDTO userForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<UserForViewDTO> UpdateAsync(int id, UserForUpdateDTO userForUpdateDTO);
        ValueTask<bool> ChangePasswordAsync(UserForChangePasswordDTO userForChangePasswordDTO);
    }
}

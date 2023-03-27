using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Hobbies;
using MyCareer.Service.DTOs.Hobbies;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Hobbies
{
    public interface IHobbyService
    {
        ValueTask<IEnumerable<Hobby>> GetAll(PaginationParams @params, Expression<Func<Hobby, bool>> expression = null);
        ValueTask<Hobby> GetAsync(Expression<Func<Hobby, bool>> expression);
        ValueTask<Hobby> CreateAsync(HobbyForCreationDTO hobbyForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Hobby> UpdateAsync(int id, HobbyForCreationDTO hobbyForCreation);
    }
}

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Hobbies;
using MyCareer.Service.DTOs.Hobbies;

namespace MyCareer.Service.Interfaces.Hobbies
{
    public interface IHobbyService
    {
        ValueTask<IQueryable<Hobby>> GetAll(PaginationParams @params, Expression<Func<Hobby, bool>> expression = null);
        ValueTask<Hobby> GetAsync(Expression<Func<Hobby, bool>> expression);
        ValueTask<Hobby> CreateAsync(HobbyForCreationDTO hobbyForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Hobby> Update(int Id, HobbyForCreationDTO hobbyForCreation);
    }
}

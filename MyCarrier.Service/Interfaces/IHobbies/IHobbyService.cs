using MyCarrier.Domain.Configurations;
using MyCarrier.Domain.Entities.Hobbies;
using MyCarrier.Domain.Entities.Resumes;
using MyCarrier.Service.DTOs.Hobbies;
using MyCarrier.Service.DTOs.Resumes;
using MyCarrier.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.Interfaces.IHobbies
{
    public interface IHobbyService
    {
        IQueryable<Hobby> GetAll(PaginationParams @params, Expression<Func<Hobby, bool>> expression = null);
        ValueTask<Hobby> GetAsync(Expression<Func<Hobby, bool>> expression);
        ValueTask<Hobby> CreateAsync(HobbyForCreationDTO hobbyForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        Hobby Update(int Id, HobbyForCreationDTO hobbyForCreation);
    }
}

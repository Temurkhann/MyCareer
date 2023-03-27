using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Freelancers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Freelancers
{
    public interface IFreelancerService
    {
        ValueTask<IEnumerable<Freelancer>> GetAll(PaginationParams @params, Expression<Func<Freelancer, bool>> expression = null);
        ValueTask<Freelancer> GetAsync(Expression<Func<Freelancer, bool>> expression);
        ValueTask<Freelancer> CreateAsync(FreelancerForCreationDTO freelancerForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Freelancer> UpdateAsync(int id, FreelancerForCreationDTO freelancerForCreation);
    }
}

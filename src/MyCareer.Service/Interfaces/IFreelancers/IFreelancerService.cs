using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Freelancers;

namespace MyCareer.Service.Interfaces.IFreelancers
{
    public interface IFreelancerService
    {
        IQueryable<Freelancer> GetAll(PaginationParams @params, Expression<Func<Freelancer, bool>> expression = null);
        ValueTask<Freelancer> GetAsync(Expression<Func<Freelancer, bool>> expression);
        ValueTask<Freelancer> CreateAsync(FreelancerForCreationDTO freelancerForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        Freelancer Update(int Id, FreelancerForCreationDTO freelancerForCreation);
    }
}

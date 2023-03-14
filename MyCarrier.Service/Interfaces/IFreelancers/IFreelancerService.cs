using MyCarrier.Domain.Configurations;
using MyCarrier.Domain.Entities.Freelancers;
using MyCarrier.Domain.Entities.Resumes;
using MyCarrier.Service.DTOs.Freelancers;
using MyCarrier.Service.DTOs.Resumes;
using MyCarrier.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.Interfaces.IFreelancers
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

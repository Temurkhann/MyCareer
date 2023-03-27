using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Contracts;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Contracts;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Contracts
{
    public class PerformerDetailService : IPerformerDetailService
    {
        private readonly IGenericRepository<Freelancer> freelancerRepository;
        private readonly IGenericRepository<PerformerDetails> performerDetailsRepository;
        private readonly IMapper mapper;

        public async ValueTask<PerformerDetails> CreateAsync(PerformerDetailForCreationDTO performerDetailForCreationDTO)
        {
            var existPerformer = await freelancerRepository.GetAsync(p => p.Id == performerDetailForCreationDTO.FreelancerId);

            if (existPerformer == null)
                throw new MyCareerException(404, "Freelancer not found");

            var createdPerformerDetails = await performerDetailsRepository.CreateAsync(mapper.Map<PerformerDetails>(performerDetailForCreationDTO));

            await performerDetailsRepository.SaveChangesAsync();

            return createdPerformerDetails;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await performerDetailsRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404,"Performer details not found");

            await performerDetailsRepository.SaveChangesAsync();

            return true;
        }

        public async ValueTask<IEnumerable<PerformerDetails>> GetAll(PaginationParams @params, Expression<Func<PerformerDetails, bool>> expression = null)
        {
            var performerDetails = performerDetailsRepository.GetAll(expression: expression, isTracking: false);

            return await performerDetails.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<PerformerDetails> GetAsync(Expression<Func<PerformerDetails, bool>> expression)
        {
            var performerDetails = await performerDetailsRepository.GetAsync(expression);

            if (performerDetails is null)
                throw new MyCareerException(404, "Performer details not found");

            return performerDetails;
        }

        public async ValueTask<PerformerDetails> UpdateAsync(int id, PerformerDetailForCreationDTO performerDetailForCreationDTO)
        {
            var existPerformerDetails = await performerDetailsRepository.GetAsync(p => p.Id == id);

            if (existPerformerDetails == null)
                throw new MyCareerException(404,"Performer Details not found");

            var existPerformer = await freelancerRepository.GetAsync(p => p.Id == performerDetailForCreationDTO.FreelancerId);

            if (existPerformer == null)
                throw new MyCareerException(404, "Freelancer not found");

            existPerformerDetails.UpdatedAt = DateTime.UtcNow;
            existPerformerDetails = await performerDetailsRepository.CreateAsync(mapper.Map(performerDetailForCreationDTO, existPerformerDetails));
            await performerDetailsRepository.SaveChangesAsync();

            return existPerformerDetails;
        }
    }
}

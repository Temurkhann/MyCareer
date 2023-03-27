using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Jobs;
using MyCareer.Domain.Entities.Skills;
using MyCareer.Service.DTOs.Jobs;
using MyCareer.Service.DTOs.Skills;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Interfaces.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Jobs
{
    public class JobService : IJobService
    {
        private readonly IGenericRepository<Job> jobRepository;
        private readonly IMapper mapper;

        public JobService(IGenericRepository<Job> jobRepository, IMapper mapper)
        {
            this.jobRepository = jobRepository;
            this.mapper = mapper;
        }

        public async ValueTask<Job> CreateAsync(JobForCreationDTO jobForCreationDTO)
        {
            var createdUserHobby = await jobRepository.CreateAsync(mapper.Map<Job>(jobForCreationDTO));
            await jobRepository.SaveChangesAsync();

            return createdUserHobby;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await jobRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "Skill not found");

            await jobRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<Job>> GetAll(PaginationParams @params, Expression<Func<Job, bool>> expression = null)
        {
            var skills = jobRepository.GetAll(expression: expression, isTracking: false, includes: new string[] { "User" });

            return await skills.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Job> GetAsync(Expression<Func<Job, bool>> expression)
        {
            var skill = await jobRepository.GetAsync(expression, false);

            if (skill is null)
                throw new MyCareerException(404, "UserHobby not found");

            return skill;
        }

        public async ValueTask<Job> UpdateAsync(int id, JobForCreationDTO jobForCreation)
        {
            var existSkill = await jobRepository.GetAsync(f => f.Id == id);

            if (existSkill is null)
                throw new MyCareerException(404, "Talent not found");

            existSkill.UpdatedAt = DateTime.UtcNow;
            existSkill = jobRepository.Update(mapper.Map(jobForCreation, existSkill));
            await jobRepository.SaveChangesAsync();

            return existSkill;
        }
    }
}

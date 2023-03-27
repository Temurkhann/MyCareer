using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Jobs;
using MyCareer.Domain.Entities.Skills;
using MyCareer.Domain.Entities.Users;
using MyCareer.Service.DTOs.Jobs;
using MyCareer.Service.DTOs.Users;
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
    public class JobSkillService : IJobSkillService
    {
        private readonly IGenericRepository<JobSkill> jobSkillRepository;
        private readonly IGenericRepository<Skill> skillRepository;
        private readonly IGenericRepository<Job> jobRepository;
        private readonly IMapper mapper;

        public JobSkillService(IGenericRepository<JobSkill> jobSkillRepository,
            IGenericRepository<Skill> skillRepository,
            IGenericRepository<Job> jobRepository,
            IMapper mapper)
        {
            this.jobSkillRepository = jobSkillRepository;
            this.skillRepository = skillRepository;
            this.jobRepository = jobRepository;
            this.mapper = mapper;
        }

        public async ValueTask<JobSkill> CreateAsync(JobSkillForCreationDTO jobForCreationDTO)
        {
            var existSkill = await skillRepository.GetAsync(
                  c => c.Id == jobForCreationDTO.SkillId);

            if (existSkill == null)
                throw new MyCareerException(404, "Skill not found");

            var existJob = await jobRepository.GetAsync(
                r => r.Id == jobForCreationDTO.JobId);

            if (existJob == null)
                throw new MyCareerException(404, "User not found");

            var createdUserLanguage = await jobSkillRepository.CreateAsync(mapper.Map<JobSkill>(jobForCreationDTO));
            await jobSkillRepository.SaveChangesAsync();

            return createdUserLanguage;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await jobSkillRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404, "JobSkill not found");

            await jobSkillRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<JobSkill>> GetAll(PaginationParams @params, Expression<Func<JobSkill, bool>> expression = null)
        {
            var userSkills = jobSkillRepository.GetAll(expression: expression, isTracking: false);

            return await userSkills.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<JobSkill> GetAsync(Expression<Func<JobSkill, bool>> expression)
        {
            var userLanguage = await jobSkillRepository.GetAsync(expression, false, new string[] { "User", "Skill" });

            if (userLanguage is null)
                throw new MyCareerException(404, "JobSkill not found");

            return userLanguage;
        }

        public async ValueTask<JobSkill> UpdateAsync(int id, JobSkillForCreationDTO jobSkillForCreation)
        {
            var existUserSkill = await jobSkillRepository.GetAsync(f => f.Id == id);

            if (existUserSkill is null)
                throw new MyCareerException(404, "JobSkill not found");

            var existSkill = await skillRepository.GetAsync(
                c => c.Id == jobSkillForCreation.SkillId);

            if (existSkill == null)
                throw new MyCareerException(404, "Skill not found");

            var existJob = await jobRepository.GetAsync(
                r => r.Id == jobSkillForCreation.JobId);

            if (existJob == null)
                throw new MyCareerException(404, "Job not found");

            existUserSkill.UpdatedAt = DateTime.UtcNow;
            existUserSkill = jobSkillRepository.Update(mapper.Map(jobSkillRepository, existUserSkill));
            await jobSkillRepository.SaveChangesAsync();

            return existUserSkill;
        }
    }
}

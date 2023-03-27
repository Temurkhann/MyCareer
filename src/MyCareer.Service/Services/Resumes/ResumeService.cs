using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Attachments;
using MyCareer.Domain.Entities.Resumes;
using MyCareer.Service.DTOs.Resumes;
using MyCareer.Service.Exceptions;
using MyCareer.Service.Extensions;
using MyCareer.Service.Interfaces.Attachments;
using MyCareer.Service.Interfaces.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Services.Resumes
{
    public class ResumeService : IResumeService
    {
        private readonly IGenericRepository<Resume> resumeRepository;
        private readonly IGenericRepository<Attachment> attachmentRepository;
        private readonly IAttachmentService attachmentService;
        private readonly IMapper mapper;

        public ResumeService(IGenericRepository<Resume> resumeRepository, IAttachmentService attachmentService, IMapper mapper, IGenericRepository<Attachment> attachmentRepository)
        {
            this.resumeRepository = resumeRepository;
            this.attachmentService = attachmentService;
            this.mapper = mapper;
            this.attachmentRepository = attachmentRepository;
        }

        public async ValueTask<Resume> CreateAsync(ResumeForCreationDTO resumeForCreationDTO)
        {
            var attachment = await attachmentService.UploadAsync(resumeForCreationDTO.FormFile.ToAttachmentOrDefault());

            var createdResume = await resumeRepository.CreateAsync(mapper.Map<Resume>(resumeForCreationDTO));

            createdResume.AttachmentId = attachment.Id;

            await resumeRepository.SaveChangesAsync();

            return createdResume;
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDeleted = await resumeRepository.DeleteAsync(id);

            if (!isDeleted)
                throw new MyCareerException(404,"Resume not found");

            await resumeRepository.SaveChangesAsync();
            return true;
        }

        public async ValueTask<IEnumerable<Resume>> GetAll(PaginationParams @params, Expression<Func<Resume, bool>> expression = null)
        {
            var resumes = resumeRepository.GetAll(expression, new string[] { "Attachment" } ,false);

            return await resumes.ToPagedList(@params).ToListAsync();
        }

        public async ValueTask<Resume> GetAsync(Expression<Func<Resume, bool>> expression)
        {
            var resume = await resumeRepository.GetAsync(expression, false, new string[] { "Attachment" });

            if (resume == null)
                throw new MyCareerException(404, "Resume not found");

            return resume;
        }

        public async ValueTask<Resume> UpdateAsync(int id, ResumeForCreationDTO resumeForCreation)
        {
            var existResume = await resumeRepository.GetAsync(r => r.Id == id);

            if (existResume == null)
                throw new MyCareerException(404, "resume not found");

            var attachment = await attachmentService.UpdateAsync(existResume.AttachmentId, resumeForCreation.FormFile.ToAttachmentOrDefault().Stream);

            existResume.UpdatedAt = DateTime.UtcNow;

            existResume = resumeRepository.Update(mapper.Map(resumeForCreation, existResume));
            await resumeRepository.SaveChangesAsync();

            return existResume;
        }
    }
}

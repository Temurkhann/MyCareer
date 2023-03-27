using AutoMapper;
using MyCareer.Data.IRepositories;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Resumes;
using MyCareer.Service.DTOs.Resumes;
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
        private readonly IAttachmentService attachmentService;
        private readonly IMapper mapper;

        public ResumeService(IGenericRepository<Resume> resumeRepository, IAttachmentService attachmentService, IMapper mapper)
        {
            this.resumeRepository = resumeRepository;
            this.attachmentService = attachmentService;
            this.mapper = mapper;
        }

        public async ValueTask<Resume> CreateAsync(ResumeForCreationDTO resumeForCreationDTO)
        {
            var attachment = await attachmentService.UploadAsync(resumeForCreationDTO.FormFile.ToAttachmentOrDefault());

            var createdResume = await resumeRepository.CreateAsync(mapper.Map<Resume>(resumeForCreationDTO));

            createdResume.AttachmentId = attachment.Id;

            await resumeRepository.SaveChangesAsync();

            return createdResume;
        }

        public ValueTask<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IEnumerable<Resume>> GetAll(PaginationParams @params, Expression<Func<Resume, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Resume> GetAsync(Expression<Func<Resume, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<Resume> UpdateAsync(int id, ResumeForCreationDTO resumeForCreation)
        {
            throw new NotImplementedException();
        }
    }
}

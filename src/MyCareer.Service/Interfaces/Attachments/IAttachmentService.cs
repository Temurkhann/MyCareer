using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Attachments;
using MyCareer.Service.DTOs.Attachments;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Attachments
{
    public interface IAttachmentService
    {
        ValueTask<IEnumerable<Attachment>> GetAll(PaginationParams @params, Expression<Func<Attachment, bool>> expression = null);
        ValueTask<Attachment> GetAsync(Expression<Func<Attachment, bool>> expression);
        ValueTask<Attachment> CreateAsync(AttachmentForCreationDTO attachmentForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Attachment> Update(int id, AttachmentForCreationDTO attachmentForCreationDTO);
    }
}

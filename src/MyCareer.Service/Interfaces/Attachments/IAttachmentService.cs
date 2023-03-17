using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Attachments;
using MyCareer.Service.DTOs.Attachments;

namespace MyCareer.Service.Interfaces.Attachments
{
    public interface IAttachmentService
    {
        ValueTask<IQueryable<Attachment>> GetAll(PaginationParams @params, Expression<Func<Attachment, bool>> expression = null);
        ValueTask<Attachment> GetAsync(Expression<Func<Attachment, bool>> expression);
        ValueTask<Attachment> CreateAsync(AttachmentForCreationDTO attachmentForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Attachment> Update(int Id, AttachmentForCreationDTO attachmentForCreationDTO);
    }
}

using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Attachments;
using MyCareer.Domain.Entities.Contacts;
using MyCareer.Service.DTOs.Attachments;
using MyCareer.Service.DTOs.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.IAttachments
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

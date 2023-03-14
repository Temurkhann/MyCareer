using MyCarrier.Domain.Configurations;
using MyCarrier.Domain.Entities.Messages;
using MyCarrier.Domain.Entities.Resumes;
using MyCarrier.Service.DTOs.Messages;
using MyCarrier.Service.DTOs.Resumes;
using MyCarrier.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.Interfaces.IMessages
{
    public interface IMessageService
    {
        IQueryable<Message> GetAll(PaginationParams @params, Expression<Func<Message, bool>> expression = null);
        ValueTask<Message> GetAsync(Expression<Func<Message, bool>> expression);
        ValueTask<Message> CreateAsync(MessageForCreationDTO messageForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        Message Update(int Id, MessageForCreationDTO messageForCreation);
    }
}

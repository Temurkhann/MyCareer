using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Chats;
using MyCareer.Domain.Entities.Contacts;
using MyCareer.Service.DTOs.Contacts;
using MyCareer.Service.DTOs.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.IChats
{
    public interface IMessageService
    {
        ValueTask<IQueryable<Message>> GetAll(PaginationParams @params, Expression<Func<Message, bool>> expression = null);
        ValueTask<Message> GetAsync(Expression<Func<Message, bool>> expression);
        ValueTask<Message> CreateAsync(MessageForCreationDTO messageForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Message> Update(int Id, MessageForCreationDTO messageForCreationDTO);
    }
}

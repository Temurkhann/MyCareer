﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Chats;
using MyCareer.Service.DTOs.Messages;

namespace MyCareer.Service.Interfaces.Messages
{
    public interface IMessageService
    {
       ValueTask<IEnumerable<Message>> GetAll(PaginationParams @params, Expression<Func<Message, bool>> expression = null);
        ValueTask<Message> GetAsync(Expression<Func<Message, bool>> expression);
        ValueTask<Message> CreateAsync(MessageForCreationDTO messageForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Message> Update(int Id, MessageForCreationDTO messageForCreation);
    }
}

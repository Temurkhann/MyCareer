﻿using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Chats;
using MyCareer.Service.DTOs.Messages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.IChats
{
    public interface IMessageService
    {
        ValueTask<IEnumerable<Message>> GetAll(PaginationParams @params, Expression<Func<Message, bool>> expression = null);
        ValueTask<Message> GetAsync(Expression<Func<Message, bool>> expression);
        ValueTask<Message> CreateAsync(MessageForCreationDTO messageForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Message> Update(int Id, MessageForCreationDTO messageForCreationDTO);
    }
}

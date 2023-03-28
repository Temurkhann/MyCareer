using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Chats;
using MyCareer.Service.DTOs.Chats;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Messages
{
    public interface IMessageService
    {
        ValueTask<Message> CreateAsync(MessageForCreationDTO messageForCreationDTO);
    }
}

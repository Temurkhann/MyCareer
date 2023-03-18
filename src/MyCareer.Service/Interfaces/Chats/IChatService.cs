using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Chats;
using MyCareer.Service.DTOs.Chats;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Chats
{
    public interface IChatService
    {
        ValueTask<IEnumerable<Chat>> GetAll(PaginationParams @params, Expression<Func<Chat, bool>> expression = null);
        ValueTask<Chat> GetAsync(Expression<Func<Chat, bool>> expression);
        ValueTask<Chat> CreateAsync(ChatForCreationDTO chatForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Chat> Update(int Id, ChatForCreationDTO chatForCreationDTO);
    }
}

using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Chats;
using MyCareer.Domain.Entities.Contacts;
using MyCareer.Service.DTOs.Chats;
using MyCareer.Service.DTOs.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.IChats
{
    public interface IChatService
    {
        ValueTask<IQueryable<Chat>> GetAll(PaginationParams @params, Expression<Func<Chat, bool>> expression = null);
        ValueTask<Chat> GetAsync(Expression<Func<Chat, bool>> expression);
        ValueTask<Chat> CreateAsync(ChatForCreationDTO chatForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Chat> Update(int Id, ChatForCreationDTO chatForCreationDTO);
    }
}

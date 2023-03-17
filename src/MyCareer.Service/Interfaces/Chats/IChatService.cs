using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Chats;
using MyCareer.Service.DTOs.Chats;

namespace MyCareer.Service.Interfaces.Chats
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

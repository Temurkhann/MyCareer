using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Contacts;
using MyCareer.Service.DTOs.Contacts;
using MyCareer.Service.DTOs.Users;

namespace MyCareer.Service.Interfaces.Contacts
{
    public interface IUserContactService
    {
        ValueTask<IQueryable<UserContact>> GetAll(PaginationParams @params, Expression<Func<UserContact, bool>> expression = null);
        ValueTask<UserContact> GetAsync(Expression<Func<UserContact, bool>> expression);
        ValueTask<UserContact> CreateAsync(ContactForCreationDTO userContactForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<UserContact> Update(int Id, UserContactForCreationDTO userContactForCreationDTO);
    }
}

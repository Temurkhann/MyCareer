using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Contacts;
using MyCareer.Service.DTOs.Contacts;
using MyCareer.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Contacts
{
    public interface IUserContactService
    {
        ValueTask<IEnumerable<UserContact>> GetAll(PaginationParams @params, Expression<Func<UserContact, bool>> expression = null);
        ValueTask<UserContact> GetAsync(Expression<Func<UserContact, bool>> expression);
        ValueTask<UserContact> CreateAsync(ContactForCreationDTO userContactForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<UserContact> Update(int id, UserContactForCreationDTO userContactForCreationDTO);
    }
}

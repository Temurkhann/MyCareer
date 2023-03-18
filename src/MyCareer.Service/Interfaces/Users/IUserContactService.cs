using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Contacts;
using MyCareer.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Users
{
    public interface IUserContactService
    {
        ValueTask<IEnumerable<UserContact>> GetAll(PaginationParams @params, Expression<Func<UserContact, bool>> expression = null);
        ValueTask<UserContact> GetAsync(Expression<Func<UserContact, bool>> expression);
        ValueTask<UserContact> CreateAsync(UserContactForCreationDTO userContactForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<UserContact> Update(int Id, UserContactForCreationDTO userContactForCreation);
    }
}

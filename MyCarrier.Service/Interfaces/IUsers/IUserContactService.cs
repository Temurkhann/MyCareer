using MyCarrier.Domain.Configurations;
using MyCarrier.Domain.Entities.Users;
using MyCarrier.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.Interfaces.Users
{
    public interface IUserContactService
    {
        IQueryable<UserContact> GetAll(PaginationParams @params, Expression<Func<UserContact, bool>> expression = null);
        ValueTask<UserContact> GetAsync(Expression<Func<UserContact, bool>> expression);
        ValueTask<UserContact> CreateAsync(UserContactForCreationDTO userContactForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        UserContact Update(int Id, UserContactForCreationDTO userContactForCreation);
    }
}

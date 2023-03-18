using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Contacts;
using MyCareer.Service.DTOs.Contacts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Contacts
{
    public interface IContactService
    {
        ValueTask<IEnumerable<Contact>> GetAll(PaginationParams @params, Expression<Func<Contact, bool>> expression = null);
        ValueTask<Contact> GetAsync(Expression<Func<Contact, bool>> expression);
        ValueTask<Contact> CreateAsync(ContactForCreationDTO contactForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Contact> Update(int Id, ContactForCreationDTO contactForCreationDTO);
    }
}

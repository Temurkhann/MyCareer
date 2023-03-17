using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Contacts;
using MyCareer.Domain.Entities.Educations;
using MyCareer.Service.DTOs.Contacts;
using MyCareer.Service.DTOs.Educations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Contacts
{
    public interface IContactService
    {
        ValueTask<IQueryable<Contact>> GetAll(PaginationParams @params, Expression<Func<Contact, bool>> expression = null);
        ValueTask<Contact> GetAsync(Expression<Func<Contact, bool>> expression);
        ValueTask<Contact> CreateAsync(ContactForCreationDTO contactForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Contact> Update(int Id, ContactForCreationDTO contactForCreationDTO);
    }
}

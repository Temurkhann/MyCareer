using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Domain.Entities.Contacts;
using MyCareer.Service.DTOs.Addresses;
using MyCareer.Service.DTOs.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.IAddresses
{
    public interface IAddressService
    {
        ValueTask<IQueryable<Address>> GetAll(PaginationParams @params, Expression<Func<Address, bool>> expression = null);
        ValueTask<Address> GetAsync(Expression<Func<Address, bool>> expression);
        ValueTask<Address> CreateAsync(AddressForCreationDTO addressForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Address> Update(int Id, AddressForCreationDTO addressForCreationDTO);
    }
}

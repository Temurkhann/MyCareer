using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Service.DTOs.Addresses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Addresses
{
    public interface IAddressService
    {
        ValueTask<IEnumerable<Address>> GetAll(PaginationParams @params, Expression<Func<Address, bool>> expression = null);
        ValueTask<Address> GetAsync(Expression<Func<Address, bool>> expression);
        ValueTask<Address> CreateAsync(AddressForCreationDTO addressForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Address> UpdateAsync(int id, AddressForCreationDTO addressForCreationDTO);
    }
}

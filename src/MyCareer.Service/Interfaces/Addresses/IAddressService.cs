﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Service.DTOs.Addresses;

namespace MyCareer.Service.Interfaces.Addresses
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
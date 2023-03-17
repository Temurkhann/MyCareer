﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Service.DTOs.Countries;

namespace MyCareer.Service.Interfaces.Addresses
{
    public interface ICountryService
    {
        ValueTask<IQueryable<Country>> GetAll(PaginationParams @params, Expression<Func<Country, bool>> expression = null);
        ValueTask<Country> GetAsync(Expression<Func<Country, bool>> expression);
        ValueTask<Country> CreateAsync(CountryForCreationDTO countryForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Country> Update(int Id, CountryForCreationDTO countryForCreationDTO);
    }
}
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Service.DTOs.Countries;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Addresses
{
    public interface ICountryService
    {
        ValueTask<IEnumerable<Country>> GetAll(PaginationParams @params, Expression<Func<Country, bool>> expression = null);
        ValueTask<Country> GetAsync(Expression<Func<Country, bool>> expression);
        ValueTask<Country> CreateAsync(CountryForCreationDTO countryForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Country> Update(int id, CountryForCreationDTO countryForCreationDTO);
    }
}

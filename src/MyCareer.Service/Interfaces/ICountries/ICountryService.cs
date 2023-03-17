using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Addresses;
using MyCareer.Domain.Entities.Educations;
using MyCareer.Service.DTOs.Countries;
using MyCareer.Service.DTOs.Educations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.ICountries
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

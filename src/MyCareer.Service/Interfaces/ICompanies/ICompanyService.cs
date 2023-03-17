using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Domain.Entities.Contacts;
using MyCareer.Service.DTOs.Companies;
using MyCareer.Service.DTOs.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.ICompanies
{
    public interface ICompanyService
    {
        ValueTask<IQueryable<Company>> GetAll(PaginationParams @params, Expression<Func<Company, bool>> expression = null);
        ValueTask<Company> GetAsync(Expression<Func<Company, bool>> expression);
        ValueTask<Company> CreateAsync(CompanyForCreationDTO companyForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Company> Update(int Id, CompanyForCreationDTO companyForCreationDTO);
    }
}

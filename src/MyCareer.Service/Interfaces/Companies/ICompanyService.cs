using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Service.DTOs.Companies;

namespace MyCareer.Service.Interfaces.Companies
{
    public interface ICompanyService
    {
        ValueTask<IEnumerable<Company>> GetAll(PaginationParams @params, Expression<Func<Company, bool>> expression = null);
        ValueTask<Company> GetAsync(Expression<Func<Company, bool>> expression);
        ValueTask<Company> CreateAsync(CompanyForCreationDTO companyForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Company> Update(int Id, CompanyForCreationDTO companyForCreationDTO);
    }
}

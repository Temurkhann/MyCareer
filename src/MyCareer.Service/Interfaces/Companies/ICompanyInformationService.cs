using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Service.DTOs.Companies;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Companies
{
    public interface ICompanyInformationService
    {
        ValueTask<IEnumerable<CompanyInformation>> GetAll(PaginationParams @params, Expression<Func<CompanyInformation, bool>> expression = null);
        ValueTask<CompanyInformation> GetAsync(Expression<Func<CompanyInformation, bool>> expression);
        ValueTask<CompanyInformation> CreateAsync(CompanyInformationForCreationDTO companyInformationForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<CompanyInformation> Update(int id, CompanyInformationForCreationDTO companyInformationForCreationDTO);
    }
}

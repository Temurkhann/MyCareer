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
    public interface ICompanyInformationService
    {
        ValueTask<IQueryable<CompanyInformation>> GetAll(PaginationParams @params, Expression<Func<CompanyInformation, bool>> expression = null);
        ValueTask<CompanyInformation> GetAsync(Expression<Func<CompanyInformation, bool>> expression);
        ValueTask<CompanyInformation> CreateAsync(CompanyInformationForCreationDTO companyInformationForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<CompanyInformation> Update(int Id, CompanyInformationForCreationDTO companyInformationForCreationDTO);
    }
}

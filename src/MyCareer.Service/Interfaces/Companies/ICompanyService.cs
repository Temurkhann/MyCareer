using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Companies;
using MyCareer.Service.DTOs.Attachments;
using MyCareer.Service.DTOs.Companies;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Companies
{
    public interface ICompanyService
    {
        ValueTask<IEnumerable<Company>> GetAll(PaginationParams @params, Expression<Func<Company, bool>> expression = null);
        ValueTask<Company> GetAsync(Expression<Func<Company, bool>> expression);
        ValueTask<Company> CreateAsync(CompanyForCreationDTO companyForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Company> Update(int id, CompanyForCreationDTO companyForCreationDTO);
        ValueTask<bool> CreateAttachmentAsync(int id, AttachmentForCreationDTO attachmentForCreationDTO);
    }
}

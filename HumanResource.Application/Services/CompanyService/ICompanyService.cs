using HumanResource.Application.Models.DTOs.CompanyDTO;
using HumanResource.Application.Models.VMs.CompanyVM;

namespace HumanResource.Application.Services.CompanyService
{
    public interface ICompanyService
    {
        Task<bool> CreateCompany(CreateCompanyDTO model, string userName);
        Task<bool> UpdateCompany(UpdateCompanyDTO model);
        Task Delete(Guid id);
        Task<List<CompanyVM>> GetCompany();
    }
}

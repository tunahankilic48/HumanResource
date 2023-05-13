using HumanResource.Application.Models.VMs.CompanyManagerVMs;
using HumanResource.Application.Models.VMs.CompanyVM;

namespace HumanResource.Application.Services.SiteAdminService
{
    public interface ISiteAdminService
    {
        Task<List<CompanyManagerRegisterRequestsVM>> GetCompanyManagerRequests();
        Task<List<CompanyVM>> GetCompanies();
        Task<CompanyDetailsVM> GetCompanyId(int id);
        Task<CompanyManagerVM> GetCompanyManager(Guid id);
    }
}

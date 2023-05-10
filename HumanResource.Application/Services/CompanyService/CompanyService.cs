using HumanResource.Application.Models.DTOs.CompanyDTO;
using HumanResource.Application.Models.VMs.CompanyVM;

namespace HumanResource.Application.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        public Task<bool> CreateCompany(CreateCompanyDTO model, string userName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCompany(UpdateCompanyDTO model)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyVM>> GetCompany()
        {
            throw new NotImplementedException();
        }

    }
}

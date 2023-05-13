using HumanResource.Application.Models.DTOs.AdvanceDTOs;
using HumanResource.Application.Models.VMs.AdvanceVMs;
using HumanResource.Application.Models.VMs.CompanyManagerVMs;

namespace HumanResource.Application.Services.AdvanceService
{
    public interface IAdvanceService
	{
		Task<bool> Create(CreateAdvanceDTO model,string userName);
		Task<bool> Update(UpdateAdvanceDTO model);
		Task Delete(int id);
		Task<UpdateAdvanceDTO> GetById(int id);
		Task<AdvanceDetailVM> AdvanceDetail(int id);
		Task<List<AdvanceVM>> GetAdvancesForPersonel(Guid id);
		Task<ProcessVM> Approve(int id);
		Task<ProcessVM> Reject(int id);
	}
}

using HumanResource.Application.Models.DTOs.AdvanceDTOs;
using HumanResource.Application.Models.VMs.AdvanceVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Application.Services.AdvanceService
{
	public interface IAdvanceService
	{
		Task Create(CreateAdvanceDTO model);
		Task Update(UpdateAdvanceDTO model);
		Task Delete(int id);
		Task<UpdateAdvanceDTO> GetById(int id);
		//Task<List<AdvanceVM>> GetAdvances();
		Task<AdvanceDetailsVM> GetAdvancesDetails(int id);
		Task<List<AdvanceVM>> GetAdvancesForPersonel(Guid id);
	}
}

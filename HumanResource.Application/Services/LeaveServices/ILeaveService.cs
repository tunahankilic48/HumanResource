using HumanResource.Application.Models.DTOs.LeaveDTO;
using HumanResource.Application.Models.VMs.LeaveVM;

namespace HumanResource.Application.Services.LeaveServices
{
    public interface ILeaveService
    {

        Task Create(CreateLeaveDTO model);
        Task Update(UpdateLeaveDTO model);
        Task Delete(int id);
        Task<UpdateLeaveDTO> GetById(int id);

        //Task<List<LeaveVM>> GetLeaves();
        Task<List<LeaveVM>> GetLeavesForPersonel(Guid id);



    }
}

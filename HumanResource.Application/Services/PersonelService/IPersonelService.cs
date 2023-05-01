using HumanResource.Application.Models.VMs.PersonelVM;

namespace HumanResource.Application.Services.PersonelService
{
    public interface IPersonelService
    {
        Task<List<PersonelLeaveRequestsVM>> GetPersonelLeaveRequests(string name);
        Task<List<PersonelAdvanceRequestsVM>> GetPersonelAdvanceRequests(string name);
        Task<PersonelVM> GetPersonel(string userName);
        Task<Guid> GetPersonelId(string name);

    }
}

using HumanResource.Application.Models.DTOs.DepartmentDTOs;
using HumanResource.Application.Models.DTOs.LeaveDTO;

namespace HumanResource.Application.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<bool> Create(CreateDepartmentDTO model, string userName);
        Task<bool> Update(UpdateDepartmentDTO model);
        Task Delete(int id);
        Task<UpdateDepartmentDTO> GetById(int id);
    }
}

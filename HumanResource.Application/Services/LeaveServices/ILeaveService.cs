using HumanResource.Application.Models.DTOs.LeaveDTO;
using HumanResource.Application.Models.VMs.LeaveVM;
using HumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Application.Services.LeaveServices
{
    internal interface ILeaveService
    {

        Task Create(CreateLeaveDTO model);
        Task Update(UpdateLeaveDTO model);
        Task Delete(int id);
        Task<UpdateLeaveDTO> GetById(int id);

        //Task<List<LeaveVM>> GetLeaves();
        Task<List<LeaveVM>> GetLeavesForPersonel(Guid id);



    }
}

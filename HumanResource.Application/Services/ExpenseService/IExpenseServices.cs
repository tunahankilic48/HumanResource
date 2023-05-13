using HumanResource.Application.Models.DTOs.ExpenseDTO;
using HumanResource.Application.Models.VMs.CompanyManagerVMs;
using HumanResource.Application.Models.VMs.ExpenseVM;

namespace HumanResource.Application.Services.ExpenseService
{
    public interface IExpenseServices
    {
        Task<bool> Create(CreateExpenseDTO model, string UserName);
        Task<bool> Update(UpdateExpenseDTO model);
        Task Delete(int id);
        Task<UpdateExpenseDTO> GetById(int id);
        Task<List<ExpenseVM>> GetExpenseForPersonel(Guid id);
        Task<ExpenseDetailVM> ExpenseDetail(int id);
        Task<ProcessVM> Approve(int id);
        Task<ProcessVM> Reject(int id);
    }
}

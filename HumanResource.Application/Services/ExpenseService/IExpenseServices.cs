using HumanResource.Application.Models.DTOs.ExpenseDTO;
using HumanResource.Application.Models.VMs.ExpenseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Application.Services.ExpenseService
{
    public interface IExpenseServices
    {
        Task<bool> Create(CreateExpenseDTO model, string UserName);
        Task<bool> Update(UpdateExpenseDTO model);
        Task Delete(int id);
        Task<UpdateExpenseDTO> GetById(int id);
        Task<List<ExpenseVM>> GetExpenseForPersonel(Guid id);
    }
}

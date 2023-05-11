using AutoMapper;
using HumanResource.Application.Models.DTOs.ExpenseDTO;
using HumanResource.Application.Models.VMs.ExpenseVM;
using HumanResource.Application.Services.PersonelService;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Enums;
using HumanResource.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Application.Services.ExpenseService
{
    public class ExpenseServices : IExpenseServices
    {
        private readonly IPersonelService _personelService;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;
        public ExpenseServices(IPersonelService personelService, IExpenseRepository expenseRepository, IMapper mapper)
        {
            _personelService = personelService;
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }


        public async Task<bool> Create(CreateExpenseDTO model, string UserName)
        {
            model.Statu.Name = Status.AwatingApproval.ToString();
            model.Statu.StatuEnumId = Status.AwatingApproval.GetHashCode();
            Expense expense = _mapper.Map<Expense>(model);
            expense.UserId = await _personelService.GetPersonelId(UserName);
            return await _expenseRepository.Add(expense);
        }

        public async Task Delete(int id)
        {
            Expense expense = await _expenseRepository.GetDefault(x => x.Id == id);
            if (expense == null)
            {
                throw new Exception("No expenditure has been entered!");
            }
            else
            {
                expense.StatuId = Status.Deleted.GetHashCode();
                expense.DeletedDate = DateTime.Now;
                await _expenseRepository.Delete(expense);
            }
        }

        public async Task<UpdateExpenseDTO> GetById(int id)
        {
            Expense expense = await _expenseRepository.GetDefault(x => x.Id == id);
            return _mapper.Map<UpdateExpenseDTO>(expense);
        }

        public async Task<List<ExpenseVM>> GetExpenseForPersonel(Guid id)
        {
            var expenses = await _expenseRepository.GetFilteredList(
                select: x => new ExpenseVM()
                {
                    Id = x.Id,
                    ExpenseDate = x.ExpenseDate.ToShortDateString(),                   
                    Amount = x.Amount,
                    CurrencyType = x.CurrencyType.Name,
                    ShortDescription = x.ShortDescription,
                    ExpenseType = x.ExpenseType.Name
                },
                where: x => x.User.Id == id && x.StatuId != Status.Deleted.GetHashCode(),
                orderby: x => x.OrderByDescending(x => x.CreatedDate),
                include: x => x.Include(x => x.User).Include(x => x.ExpenseType).Include(x => x.CurrencyType)
                );

            return expenses;
        }

        public async Task<bool> Update(UpdateExpenseDTO model)
        {
            Expense expense = _mapper.Map<Expense>(model);
            return await _expenseRepository.Update(expense);
        }
    }
}

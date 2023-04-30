using HumanResource.Application.Models.VMs.PersonelVM;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Repositries;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Application.Services.PersonelService
{
    internal class PersonelService : IPersonelService
    {
        private readonly IAppUserRepository _userRepository;
        private readonly ILeaveRepository _leaveRepository;
        private readonly IAdvanceRepository _advanceRepository;

        public PersonelService(IAppUserRepository userRepository, ILeaveRepository leaveRepository, IAdvanceRepository advanceRepository)
        {
            _userRepository = userRepository;
            _leaveRepository = leaveRepository;
            _advanceRepository = advanceRepository;
        }

        public async Task<PersonelVM> GetPersonel(string userName)
        {
            var personel = await _userRepository.GetFilteredFirstOrDefault(
               select: x => new PersonelVM()
               {
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   Department = x.Department.Name
               },
               where: x => x.UserName == userName,
               orderby: null,
               include: x => x.Include(x => x.Department)
               );

            return personel;
        }

        public async Task<List<PersonelAdvanceRequestsVM>> GetPersonelAdvanceRequests(string name)
        {
            var personelLeaveRequests = await _advanceRepository.GetFilteredList(
               select: x => new PersonelAdvanceRequestsVM()
               {
                   Amount = x.Amount,
                   NumberOfInstallments = x.NumberOfInstallments,
                   CreatedDate = x.CreatedDate

               },
               where: x => x.User.UserName == name,
               orderby: null,
               include: x => x.Include(x=>x.User)
               );

            return personelLeaveRequests;

        }

        public async Task<List<PersonelLeaveRequestsVM>> GetPersonelLeaveRequests(string name)
        {
            var personelLeaveRequests = await _leaveRepository.GetFilteredList(
              select: x => new PersonelLeaveRequestsVM()
              {
                  StartDate = x.StartDate,
                  EndDate = x.EndDate,
                  ReturnDate = x.ReturnDate,
                  LeaveType = x.LeaveType.Name

              },
              where: x => x.User.UserName == name,
              orderby: null,
              include: x => x.Include(x => x.LeaveType).Include(x=>x.User)
              );

            return personelLeaveRequests;
        }
    }
}

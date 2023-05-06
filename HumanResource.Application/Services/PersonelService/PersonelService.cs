using HumanResource.Application.Models.VMs.PersonelVM;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Enums;
using HumanResource.Domain.Repositries;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Application.Services.PersonelService
{
    public class PersonelService : IPersonelService
    {
        private readonly IAppUserRepository _userRepository;
        private readonly ILeaveRepository _leaveRepository;
        private readonly IAdvanceRepository _advanceRepository;
        private readonly UserManager<AppUser> _userManager;


        public PersonelService(IAppUserRepository userRepository, ILeaveRepository leaveRepository, IAdvanceRepository advanceRepository, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _leaveRepository = leaveRepository;
            _advanceRepository = advanceRepository;
            _userManager = userManager;
        }

        public async Task<PersonelVM> GetPersonel(string userName)
        {
            var personel = await _userRepository.GetFilteredFirstOrDefault(
               select: x => new PersonelVM()
               {
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   Image = x.ImagePath == null ? "/media/images/noImage.png" : x.ImagePath,
                   FullName = x.FirstName + " " + x.LastName
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
                   Id = x.Id,
                   Amount = x.Amount,
                   NumberOfInstallments = x.NumberOfInstallments,
                   CreatedDate = x.CreatedDate

               },
               where: x => x.User.UserName == name && x.Statu.Name == Status.AwatingApproval.ToString(),
               orderby: x=>x.OrderByDescending(x=>x.CreatedDate),
               include: x => x.Include(x => x.User)
               );

            return personelLeaveRequests;

        }

        public async Task<Guid> GetPersonelId(string name)
        {
            AppUser user = await _userManager.FindByNameAsync(name);
            return user.Id;

        }

        public async Task<List<PersonelLeaveRequestsVM>> GetPersonelLeaveRequests(string name)
        {
            var personelLeaveRequests = await _leaveRepository.GetFilteredList(
              select: x => new PersonelLeaveRequestsVM()
              {
                  Id = x.Id,
                  StartDate = x.StartDate.ToShortDateString(),
                  EndDate = x.EndDate.ToShortDateString(),
                  ReturnDate = x.ReturnDate.ToShortDateString(),
                  LeaveType = x.LeaveType.Name

              },
              where: x => x.User.UserName == name && x.Statu.Name == Status.AwatingApproval.ToString(),
              orderby: x => x.OrderByDescending(x => x.CreatedDate),
              include: x => x.Include(x => x.LeaveType).Include(x=>x.User)
              );

            return personelLeaveRequests;
        }


    }
}

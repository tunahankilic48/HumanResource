using AutoMapper;
using HumanResource.Application.Models.DTOs.LeaveDTO;
using HumanResource.Application.Models.VMs.LeaveVM;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Repositries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Application.Services.LeaveServices
{
    internal class LeaveService : ILeaveService
    {
        private readonly ILeaveRepository _leaveRepository;
        private readonly IMapper _mapper;


        public LeaveService(ILeaveRepository leaveRepository, IMapper mapper)
        {
            _leaveRepository = leaveRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateLeaveDTO model)
        {
            Leave leave = _mapper.Map<Leave>(model);
            await _leaveRepository.Add(leave);
        }

        public async Task Delete(int id)
        {
            Leave leave = await _leaveRepository.GetDefault(x => x.Id == id);
            //leave.Statu = Statu.Passive;
            leave.DeletedDate = DateTime.Now;
            _leaveRepository.Delete(leave);
        }

        public async Task<UpdateLeaveDTO> GetById(int id)
        {
            Leave leave = await _leaveRepository.GetDefault(x => x.Id == id);
            return _mapper.Map<UpdateLeaveDTO>(leave);
        }

        public async Task<List<LeaveVM>> GetLeavesForPersonel(Guid id)
        {
            var comments = await _leaveRepository.GetFilteredList(
                select: x => new LeaveVM()
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
                    CreatedDate = x.CreatedDate,
                    EndDate = x.EndDate,
                    ReturnDate = x.ReturnDate,
                    LeavePeriod = x.LeavePeriod,
                    LeaveTypeId = x.Leave.Name
                },

                where: x => x.User.Id == id,
                orderby: x => x.OrderByDescending(x => x.CreatedDate),
                include: x => x.Include(x => x.User).Include(x=>x.Leave)
                );

            return comments;
        }

        public async Task Update(UpdateLeaveDTO model)
        {
            Leave leave = _mapper.Map<Leave>(model);
            await _leaveRepository.Update(leave);
        }
    }
}

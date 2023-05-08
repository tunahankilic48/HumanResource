using AutoMapper;
using HumanResource.Application.Models.DTOs.AdvanceDTOs;
using HumanResource.Application.Models.VMs.AdvanceVMs;
using HumanResource.Application.Services.PersonelService;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Enums;
using HumanResource.Domain.Repositries;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Application.Services.AdvanceService
{
    public class AdvanceService : IAdvanceService
	{
		private readonly IAdvanceRepository _advanceRepository;
		private readonly IAppUserRepository _appUserRepository;
		private readonly IMapper _mapper;
		private readonly IPersonelService _personelService;

        public AdvanceService(IAdvanceRepository advanceRepository, IMapper mapper, IAppUserRepository appUserRepository, IPersonelService personelService)
        {
            _advanceRepository = advanceRepository;
            _mapper = mapper;
            _appUserRepository = appUserRepository;
            _personelService = personelService;
        }

        public async Task<bool> Create(CreateAdvanceDTO model,string userName)
		{
            model.Statu.Name = Status.AwatingApproval.ToString();
            model.Statu.StatuEnumId = Status.AwatingApproval.GetHashCode();
            Advance advance = _mapper.Map<Advance>(model);
            advance.UserId = await _personelService.GetPersonelId(userName);
            return await _advanceRepository.Add(advance);
		}


		public async Task Delete(int id)
		{
			Advance advance = await _advanceRepository.GetDefault(x => x.Id == id);
			if (advance != null)
			{
                advance.StatuId = Status.Deleted.GetHashCode();
                advance.DeletedDate = DateTime.Now;
				await _advanceRepository.Delete(advance);
			}
		}

		public async Task<List<AdvanceVM>> GetAdvancesForPersonel(Guid id)
		{
			var advances = await _advanceRepository.GetFilteredList(
				select: x => new AdvanceVM()
				{
					Id = x.Id,
					Amount = x.Amount,
					NumberOfInstallments = x.NumberOfInstallments
				},
				where: x => x.User.Id == id && x.StatuId != Status.Deleted.GetHashCode(),
				orderby: x => x.OrderByDescending(x => x.CreatedDate),
				include: x => x.Include(x => x.User).Include(x => x.Statu)
                );
			return advances;
		}


		public async Task<UpdateAdvanceDTO> GetById(int id)
		{
			Advance advance = await _advanceRepository.GetDefault(x => x.Id == id);
			return _mapper.Map<UpdateAdvanceDTO>(advance);
		}

		public async Task<bool> Update(UpdateAdvanceDTO model)
		{
				Advance advance = _mapper.Map<Advance>(model);
				return await _advanceRepository.Update(advance);
		}
	}
}

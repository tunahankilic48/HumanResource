using AutoMapper;
using HumanResource.Application.Models.DTOs.AdvanceDTOs;
using HumanResource.Application.Models.VMs.AdvanceVMs;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Repositries;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Application.Services.AdvanceService
{
    public class AdvanceService : IAdvanceService
	{
		private readonly IAdvanceRepository _advanceRepository;
		private readonly IAppUserRepository _appUserRepository;
		private readonly IMapper _mapper;

		public AdvanceService(IAdvanceRepository advanceRepository, IMapper mapper, IAppUserRepository appUserRepository)
		{
			_advanceRepository = advanceRepository;
			_mapper = mapper;
			_appUserRepository = appUserRepository;
		}

		public async Task Create(CreateAdvanceDTO model)
		{
			Advance advance = _mapper.Map<Advance>(model);
			await _advanceRepository.Add(advance);
		}


		public async Task Delete(int id)
		{
			Advance advance = await _advanceRepository.GetDefault(x => x.Id == id);
			if (advance != null)
			{
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
				where: x => x.User.Id == id,
				orderby: x => x.OrderByDescending(x => x.CreatedDate),
				include: x => x.Include(x => x.User)
				);
			return advances;
		}


		public async Task<UpdateAdvanceDTO> GetById(int id)
		{
			Advance advance = await _advanceRepository.GetDefault(x => x.Id == id);
			var model = _mapper.Map<UpdateAdvanceDTO>(advance);
			return model;

		}

		public async Task Update(UpdateAdvanceDTO model)
		{
			if (model != null)
			{
				var advance = _mapper.Map<Advance>(model);
				await _advanceRepository.Update(advance);
			}
		}
	}
}

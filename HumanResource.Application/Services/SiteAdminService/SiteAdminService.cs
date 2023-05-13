using AutoMapper;
using HumanResource.Application.Models.VMs.CompanyManagerVMs;
using HumanResource.Application.Models.VMs.CompanyVM;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Enums;
using HumanResource.Domain.Repositories;
using HumanResource.Domain.Repositries;
using HumanResource.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Application.Services.SiteAdminService
{
	public class SiteAdminService : ISiteAdminService
	{
		private readonly ICompanyRepository _companyRepository;
		private readonly IMapper _mapper;
		private readonly IAppUserRepository _appUserRepository;
		public SiteAdminService(ICompanyRepository companyRepository, IMapper mapper, IAppUserRepository appUserRepository)
		{
			_companyRepository = companyRepository;
			_mapper = mapper;
			_appUserRepository = appUserRepository;
		}

		public async Task<List<CompanyVM>> GetCompanies()
		{
			var companies = await _companyRepository.GetFilteredList(
				 select: x => new CompanyVM()
				 {
					 Id = x.Id,
					 CompanyName = x.CompanyName,
					 PhoneNumber = x.PhoneNumber,
				 },
				 where: x => x.StatuId == Status.Awating_Approval.GetHashCode() && x.StatuId == Status.Active.GetHashCode() && x.StatuId == Status.Passive.GetHashCode(),
				 orderby: x => x.OrderByDescending(x => x.CreatedDate)
				 );
			return companies;
		}

		public async Task<CompanyDetailsVM> GetCompanyId(int id)
		{
			Company company = await _companyRepository.GetDefault(x => x.Id == id);
			return _mapper.Map<CompanyDetailsVM>(company);
		}

		public async Task<List<CompanyManagerRegisterRequestsVM>> GetCompanyManagerRequests()
		{
			var companies = await _appUserRepository.GetFilteredList(
				 select: x => new CompanyManagerRegisterRequestsVM()
				 {
					 UserId = x.Id,
					 CompanyName = x.Company.CompanyName,
					 FullName = x.FirstName + " " + x.LastName
				 },
				 where: x => x.Company.StatuId == Status.Awating_Approval.GetHashCode(),
				 orderby: x => x.OrderByDescending(x => x.CreatedDate),
				 include: x => x.Include(x => x.Company)
				 );
			return companies;
		}

		public async Task<CompanyManagerVM> GetCompanyManager(Guid id)
		{
			var companyManager = await _appUserRepository.GetFilteredFirstOrDefault(
			  select: x => new CompanyManagerVM()
			  {
				  Id = x.Id,
				  FullName = x.FirstName + " " + x.LastName,
				  UserName = x.UserName,
				  Email = x.Email
			  },
			  where: null
			  ); ;
			return companyManager;
		}
		public async Task<CompanyDetailsVM> GetCompanyDetails(Guid id)
		{
			var companyManager = await _companyRepository.GetFilteredFirstOrDefault(
			  select: x => new CompanyDetailsVM()
			  {
				  Id = x.Id,
				  CompanyName = x.CompanyName,
				  TaxNumber = x.TaxNumber,
				  TaxOfficeName = x.TaxOfficeName,
				  PhoneNumber = x.PhoneNumber,
				  NumberOfEmployee = x.NumberOfEmployee,
				  City = x.Address.District.City.Name,
				  District = x.Address.District.Name,
				  AddressDescription = x.Address.Description,

			  },
			  where: x => x.StatuId == Status.Awating_Approval.GetHashCode(),
			  orderby: null,
              include: x => x.Include(x => x.Address).Include(x => x.Address.District)
			  ); ;
			return companyManager;
		}
		public async Task<ProcessVM> Approve(int id)
		{
			Company company = await _companyRepository.GetDefault(x => x.Id == id);
			company.StatuId = Status.Active.GetHashCode();
			//var user = await _appUserRepository.GetDefault(x => x.Id == company.ManagerId);
			return new ProcessVM() { Result = await _companyRepository.Update(company)};
		}
		public async Task<ProcessVM> Reject(int id)
		{
			Company company = await _companyRepository.GetDefault(x => x.Id == id);
			company.StatuId = Status.Passive.GetHashCode();
			//var user = await _appUserRepository.GetDefault(x => x.Id == company.ManagerId);
			return new ProcessVM() { Result = await _companyRepository.Update(company)};
		}

	}
}

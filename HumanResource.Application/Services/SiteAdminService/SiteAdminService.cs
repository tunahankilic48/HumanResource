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

		public async Task<List<CompanyVM>> GetCompanies(Guid id)
		{
            var companies = await _appUserRepository.GetFilteredList(
                 select: x => new CompanyVM()
                 {
                     UserId = x.Id,
                     CompanyId = x.CompanyId,
                     CompanyName = x.Company.CompanyName,
                     FullName = x.FirstName + " " + x.LastName,
					 Statu = x.Statu.Name
                 },
                 where: x => x.Company.StatuId != Status.Deleted.GetHashCode(),
                 orderby: x => x.OrderByDescending(x => x.CreatedDate),
                 include: x => x.Include(x => x.Company)
                 );
            return companies;
        }


		public async Task<List<CompanyManagerRegisterRequestsVM>> GetCompanyManagerRequests()
		{
			var companies = await _appUserRepository.GetFilteredList(
				 select: x => new CompanyManagerRegisterRequestsVM()
				 {
					 UserId =x.Id,
					 CompanyId = x.CompanyId,
					 CompanyName = x.Company.CompanyName,
					 FullName = x.FirstName + " " + x.LastName
				 },
				 where: x => x.Company.StatuId == Status.Awating_Approval.GetHashCode(),
				 orderby: x => x.OrderByDescending(x => x.CreatedDate),
				 include: x => x.Include(x => x.Company) 
				 );
			return companies;
		}
		public async Task<CompanyDetailsVM> GetCompanyDetails(Guid id)
		{
			var company = await _appUserRepository.GetFilteredFirstOrDefault(
			  select: x => new CompanyDetailsVM()
			  {
				  Id = x.Company.Id,
                  FullName = x.FirstName + " " + x.LastName,
                  CompanyName = x.Company.CompanyName,
				  TaxNumber = x.Company.TaxNumber,
				  TaxOfficeName = x.Company.TaxOfficeName,
				  PhoneNumber = x.Company.PhoneNumber,
				  NumberOfEmployee = x.Company.NumberOfEmployee,
				  City = x.Company.Address.District.City.Name,
				  District = x.Company.Address.District.Name,
				  AddressDescription = x.Company.Address.Description,

			  },
			  where: x => x.Company.StatuId == Status.Awating_Approval.GetHashCode() && x.Id == id,
			  orderby: null,
              include: x => x.Include(x => x.Company) .Include(x => x.Company.Address).Include(x => x.Company.Address.District)
              );
			return company; 
		}
		public async Task<ProcessVM> Approve(int id)
		{
			Company company = await _companyRepository.GetDefault(x => x.Id == id);
			company.StatuId = Status.Active.GetHashCode();
			var user = await _appUserRepository.GetDefault(x => x.CompanyId == company.Id);
			user.EmailConfirmed = true;
			return new ProcessVM() { Result = await _companyRepository.Update(company), UserEmail=user.Email};
		}
		public async Task<ProcessVM> Reject(int id)
		{
			Company company = await _companyRepository.GetDefault(x => x.Id == id);
			company.StatuId = Status.Passive.GetHashCode();
			var user = await _appUserRepository.GetDefault(x => x.CompanyId == company.Id);
			return new ProcessVM() { Result = await _companyRepository.Update(company),UserEmail= user.Email };
		}

	}
}

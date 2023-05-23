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
            var companies = await _appUserRepository.GetFilteredList(
                 select: x => new CompanyVM()
                 {
                     UserId = x.Id,
                     CompanyId = x.CompanyId,
                     CompanyName = x.Company.CompanyName,
                     FullName = x.FirstName + " " + x.LastName,
                     PhoneNumber = x.PhoneNumber,
                     Email = x.Email,
                     Statu = x.Company.Statu.Name,
                 },
                 where: x => x.Company.CompanyName != null,
                 orderby: x => x.OrderByDescending(x => x.CreatedDate),
                 include: x => x.Include(x => x.Statu) .Include(x => x.Company)
                 );
            return companies;
        }


        public async Task<List<CompanyManagerRegisterRequestsVM>> GetCompanyManagerRequests()
        {
            var companies = await _appUserRepository.GetFilteredList(
                 select: x => new CompanyManagerRegisterRequestsVM()
                 {
                     UserId = x.Id,
                     CompanyId = x.CompanyId,
                     CompanyName = x.Company.CompanyName,
                     FullName = x.FirstName + " " + x.LastName,
                     PhoneNumber = x.PhoneNumber,
                     Email= x.Email,
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
              include: x => x.Include(x => x.Company).Include(x => x.Company.Address).Include(x => x.Company.Address.District)
              );
            return company;
        }
        public async Task<ProcessVM> Approve(int id)
        {
            Company company = await _companyRepository.GetDefault(x => x.Id == id);
            company.StatuId = Status.Active.GetHashCode();
            var user = await _appUserRepository.GetDefault(x => x.CompanyId == company.Id);
            user.EmailConfirmed = true;
            return new ProcessVM() { Result = await _companyRepository.Update(company), UserEmail = user.Email };
        }
        public async Task<ProcessVM> Reject(int id)
        {
            Company company = await _companyRepository.GetDefault(x => x.Id == id);
            company.StatuId = Status.Rejected.GetHashCode();
            var user = await _appUserRepository.GetDefault(x => x.CompanyId == company.Id);
            return new ProcessVM() { Result = await _companyRepository.Update(company), UserEmail = user.Email };
        }
        public async Task<CompanyDetailsVM> GetCompanyListDetails(string companyName)
        {
            var company = await _appUserRepository.GetFilteredFirstOrDefault(
              select: x => new CompanyDetailsVM()
              {
                  Id = x.Company.Id,
                  CompanyName = x.Company.CompanyName,
                  TaxNumber = x.Company.TaxNumber,
                  TaxOfficeName = x.Company.TaxOfficeName,
                  PhoneNumber = x.Company.PhoneNumber,
                  NumberOfEmployee = x.Company.NumberOfEmployee,
                  City = x.Company.Address.District.City.Name,
                  District = x.Company.Address.District.Name,
                  AddressDescription = x.Company.Address.Description,

              },
              where: x => x.Company.CompanyName == companyName,
              orderby: null,
              include: x => x.Include(x => x.Company).Include(x => x.Company.Address).Include(x => x.Company.Address.District)
              );
            return company;
        }

        public async Task<List<CompanySectorPieVM>> CompaniesDistributionBySectors()
        {
            List<CompanySectorPieVM> CompaniesDistributionBySectors = new List<CompanySectorPieVM>();
            var companies = await _companyRepository.GetFilteredList(
                select: x => new CompanySectorVM()
                {
                    CompanyName = x.CompanyName,
                    CompanySectorId = x.CompanySectorId
                },
                where: null,
                orderby: x => x.OrderBy(x => x.CompanySectorId)
                );
            double companyCount = companies.Count;
            for (int i = 1; i <= Enum.GetValues(typeof(CompanySectors)).Length; i++)
            {
                var tempCompanies = await _companyRepository.GetFilteredList(
                select: x => new CompanySectorVM()
                {
                    CompanyName = x.CompanyName,
                    CompanySectorId = x.CompanySectorId,
                    CompanySectorName = x.CompanySector.Name,
                },
                where: x => x.CompanySectorId == i,
                orderby: null,
                include: x => x.Include(x => x.CompanySector)
                );
                
                if (tempCompanies.Count != 0)
                {
                    double ratio = (tempCompanies.Count / companyCount) * 100;
                    CompaniesDistributionBySectors.Add(new CompanySectorPieVM($"{tempCompanies[0].CompanySectorName} ({tempCompanies.Count})", Math.Round(ratio, 2)));
                }

            }


            //CompaniesDistributionBySectors.Add(new CompanySectorVM("Samsung", 25));
            //CompaniesDistributionBySectors.Add(new CompanySectorVM("Micromax", 13));
            //CompaniesDistributionBySectors.Add(new CompanySectorVM("Lenovo", 8));
            //CompaniesDistributionBySectors.Add(new CompanySectorVM("Intex", 7));
            //CompaniesDistributionBySectors.Add(new CompanySectorVM("Reliance", 6.8));
            //CompaniesDistributionBySectors.Add(new CompanySectorVM("Others", 40.2));
            return CompaniesDistributionBySectors;
        }

        //To Do: 1 method kalacak cshtml tarafı düzeltilecek
    }
}

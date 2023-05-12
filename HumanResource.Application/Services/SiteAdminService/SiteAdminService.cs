using AutoMapper;
using HumanResource.Application.Models.VMs.CompanyManagerVMs;
using HumanResource.Application.Models.VMs.CompanyVM;
using HumanResource.Application.Services.CompanyManagerService;
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
                     PhoneNumber= x.PhoneNumber,
                 },
                 where: x => x.StatuId == Status.AwatingApproval.GetHashCode() && x.StatuId == Status.Active.GetHashCode() && x.StatuId == Status.Passive.GetHashCode(),
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
                 where: x => x.StatuId == Status.AwatingApproval.GetHashCode(),
                 orderby: x => x.OrderByDescending(x => x.CreatedDate),
                 include: x => x.Include(x => x.Company)
                 );
            return companies;
        }
    }
}

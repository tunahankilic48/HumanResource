using HumanResource.Application.Models.VMs.AddressVM;

namespace HumanResource.Application.Services.AddressService
{
    public interface IAddressService
    {
        Task<List<CityVM>> GetCities();
        Task<List<DistrictVM>> GetDistricts(int cityId);
        Task<List<DistrictVM>> GetDistricts();
    }
}

using AutoMapper;
using HumanResource.Application.Models.DTOs.AccountDTO;
using HumanResource.Domain.Entities;

namespace HumanResource.Application.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, RegisterDTO>().ReverseMap();

            CreateMap<Leave, CreateLeaveDTO>().ReverseMap();
            CreateMap<Leave, UpdateLeaveDTO>().ReverseMap();

            CreateMap<Advance, CreateAdvanceDTO>().ReverseMap();
            CreateMap<Advance, UpdateAdvanceDTO>().ReverseMap();

        }
    }
}

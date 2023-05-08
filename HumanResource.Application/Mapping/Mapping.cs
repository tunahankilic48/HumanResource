﻿using AutoMapper;
using HumanResource.Application.Models.DTOs.AccountDTO;
using HumanResource.Application.Models.DTOs.AdvanceDTOs;
using HumanResource.Application.Models.DTOs.DepartmentDTOs;
using HumanResource.Application.Models.DTOs.ExpenseDTO;
using HumanResource.Application.Models.DTOs.LeaveDTO;
using HumanResource.Application.Models.DTOs.TitleDTOs;
using HumanResource.Domain.Entities;

namespace HumanResource.Application.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            CreateMap<AppUser, UpdateProfileDTO>().ReverseMap();

            CreateMap<Leave, CreateLeaveDTO>().ReverseMap();
            CreateMap<Leave, UpdateLeaveDTO>().ReverseMap();

            CreateMap<Advance, CreateAdvanceDTO>().ReverseMap();
            CreateMap<Advance, UpdateAdvanceDTO>().ReverseMap();

            CreateMap<Department, CreateDepartmentDTO>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDTO>().ReverseMap();

            CreateMap<Title, CreateTitleDTO>().ReverseMap();
            CreateMap<Title, UpdateTitleDTO>().ReverseMap();

            CreateMap<Expense, CreateExpenseDTO>().ReverseMap();
            CreateMap<Expense, UpdateExpenseDTO>().ReverseMap();

        }
    }
}

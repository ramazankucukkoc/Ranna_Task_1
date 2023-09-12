using Application.Features.Adminsrators.Command.CreateAdmin;
using Application.Features.Adminsrators.Command.DeleteAdmin;
using Application.Features.Adminsrators.Command.UpdateAdmin;
using Application.Features.Adminsrators.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adminsrators.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Adminstrator, CreateAdminDto>().ReverseMap();
            CreateMap<Adminstrator, CreateAdminCommand>().ReverseMap();

            CreateMap<Adminstrator, DeleteAdminDto>().ReverseMap();
            CreateMap<Adminstrator, DeleteAdminCommand>().ReverseMap();

            CreateMap<Adminstrator, UpdateAdminDto>().ReverseMap();
            CreateMap<Adminstrator, UpdateAdminCommand>().ReverseMap();


            CreateMap<Adminstrator, AdminListDto>().ReverseMap();
            CreateMap<IPaginate<Adminstrator>, GetListResponse<AdminListDto>>().ReverseMap();

        }
    }
}

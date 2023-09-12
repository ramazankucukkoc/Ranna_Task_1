using Application.Features.Users.Commands;
using Application.Features.Users.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Command---------------------------

            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();

            CreateMap<User, DeletedUserDto>().ReverseMap();
            CreateMap<User, DeleteUserCommnad>().ReverseMap();


            //Queries-----------------------------
            CreateMap<User, UserListDto>()
                .ForMember(x => x.OperationClaims, opt => opt.MapFrom(x => x.UserOperationClaims.Select(x => x.OperationClaim))).ReverseMap();

            CreateMap<User, GetByIdUserDto>()
            .ForMember(x => x.OperationClaims, opt => opt.MapFrom(x => x.UserOperationClaims.Select(x => x.OperationClaim))).ReverseMap();


            CreateMap<IPaginate<User>, GetListResponse<UserListDto>>().ReverseMap();




        }

    }
}

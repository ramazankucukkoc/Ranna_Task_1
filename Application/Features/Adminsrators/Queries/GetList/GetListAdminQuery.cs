using Application.Features.Adminsrators.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adminsrators.Queries.GetList
{
    public class GetListAdminQuery:IRequest<GetListResponse<AdminListDto>>
    {
        public PageRequest  PageRequest { get; set; }

        public class GetListAdminQueryHandler : IRequestHandler<GetListAdminQuery, GetListResponse<AdminListDto>>
        {
            private readonly IAdminstratorRepository _adminstratorRepository;
            private readonly IMapper _mapper;

            public GetListAdminQueryHandler(IAdminstratorRepository adminstratorRepository, IMapper mapper)
            {
                _adminstratorRepository = adminstratorRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<AdminListDto>> Handle(GetListAdminQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Adminstrator> admins = await _adminstratorRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                GetListResponse<AdminListDto> mappedBrandListModel =_mapper.Map<GetListResponse<AdminListDto>>(admins);
                return mappedBrandListModel;
            }
        }
    }
}

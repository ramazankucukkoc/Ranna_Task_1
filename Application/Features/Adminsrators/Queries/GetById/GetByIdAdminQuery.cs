using Application.Features.Adminsrators.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Adminsrators.Queries.GetById
{
    public class GetByIdAdminQuery:IRequest<AdminListDto>
    {
        public int Id { get; set; }

        public class GetByIdAdminQueryHandler : IRequestHandler<GetByIdAdminQuery, AdminListDto>
        {
            private readonly IMapper _mapper;
            private readonly IAdminstratorRepository _adminstratorRepository;

            public GetByIdAdminQueryHandler(IMapper mapper, IAdminstratorRepository adminstratorRepository)
            {
                _mapper = mapper;
                _adminstratorRepository = adminstratorRepository;
            }

            public async Task<AdminListDto> Handle(GetByIdAdminQuery request, CancellationToken cancellationToken)
            {
                Adminstrator? adminstrator = await _adminstratorRepository.GetAsync(a => a.Id == request.Id);
                AdminListDto adminListDto =_mapper.Map<AdminListDto>(adminstrator);
                return adminListDto;
            }
        }
    }
}

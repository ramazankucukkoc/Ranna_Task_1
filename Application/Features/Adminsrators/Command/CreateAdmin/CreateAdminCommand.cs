using Application.Features.Adminsrators.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adminsrators.Command.CreateAdmin
{
    public class CreateAdminCommand:IRequest<CreateAdminDto>,ISecuredRequest
    {

        public string Name { get; set; }

        public string[] Roles => new[] { "Admin" };

        public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, CreateAdminDto>
        {
            private readonly IMapper _mapper;
            private readonly IAdminstratorRepository _adminstratorRepository;

            public CreateAdminCommandHandler(IMapper mapper, IAdminstratorRepository adminstratorRepository)
            {
                _mapper = mapper;
                _adminstratorRepository = adminstratorRepository;
            }

            public async Task<CreateAdminDto> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
            {
                Adminstrator mappedAdmin = _mapper.Map<Adminstrator>(request);
                Adminstrator createdAdmin=await _adminstratorRepository.AddAsync(mappedAdmin);
                CreateAdminDto createAdminDto = _mapper.Map<CreateAdminDto>(createdAdmin);
                return createAdminDto;
            }
        }

    }
}

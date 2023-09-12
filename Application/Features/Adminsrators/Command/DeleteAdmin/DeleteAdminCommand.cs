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

namespace Application.Features.Adminsrators.Command.DeleteAdmin
{
    public class DeleteAdminCommand : IRequest<DeleteAdminDto>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { "Silver" };

        public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, DeleteAdminDto>
        {
            private readonly IMapper _mapper;
            private readonly IAdminstratorRepository _adminstratorRepository;

            public DeleteAdminCommandHandler(IMapper mapper, IAdminstratorRepository adminstratorRepository)
            {
                _mapper = mapper;
                _adminstratorRepository = adminstratorRepository;
            }

            public async Task<DeleteAdminDto> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
            {
                Adminstrator mappedAdmin = _mapper.Map<Adminstrator>(request);
                Adminstrator deletedAdmin = await _adminstratorRepository.DeleteAsync(mappedAdmin);
                DeleteAdminDto createAdminDto = _mapper.Map<DeleteAdminDto>(deletedAdmin);
                return createAdminDto;
            }
        }
    }
}

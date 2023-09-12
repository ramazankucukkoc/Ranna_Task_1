using Application.Features.Adminsrators.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;

namespace Application.Features.Adminsrators.Command.UpdateAdmin
{
    public class UpdateAdminCommand : IRequest<UpdateAdminDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string[] Roles => new[] {  "Garden" };

        public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, UpdateAdminDto>
        {
            private readonly IMapper _mapper;
            private readonly IAdminstratorRepository _adminstratorRepository;

            public UpdateAdminCommandHandler(IMapper mapper, IAdminstratorRepository adminstratorRepository)
            {
                _mapper = mapper;
                _adminstratorRepository = adminstratorRepository;
            }

            public async Task<UpdateAdminDto> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
            {
                Adminstrator? mappedAdmin = await _adminstratorRepository.GetAsync(a => a.Id == request.Id);
                mappedAdmin.Name = request.Name;


                Adminstrator updatedAdmin = await _adminstratorRepository.UpdateAsync(mappedAdmin);
                UpdateAdminDto createAdminDto = _mapper.Map<UpdateAdminDto>(updatedAdmin);
                return createAdminDto;
            }
        }
    }
}

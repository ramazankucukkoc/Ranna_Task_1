using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IAdminstratorRepository : IAsyncRepository<Adminstrator>
    {
    }
}

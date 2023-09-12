using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class AdminstratorRepository : EfRepositoryBase<Adminstrator, BaseDbContext>, IAdminstratorRepository
    {
        public AdminstratorRepository(BaseDbContext context) : base(context)
        {

        }

    }
}

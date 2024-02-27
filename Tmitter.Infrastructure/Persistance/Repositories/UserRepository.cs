using Tmitter.Application.Common.Interfaces.Repositories;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(TmitterDbContext context) : base(context)
    {
    }
}
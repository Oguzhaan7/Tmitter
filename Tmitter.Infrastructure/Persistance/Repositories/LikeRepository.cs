using Tmitter.Application.Common.Interfaces.Repositories;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance.Repositories;

public class LikeRepository : Repository<Like>, ILikeRepository
{
    public LikeRepository(TmitterDbContext context) : base(context)
    {
    }
}
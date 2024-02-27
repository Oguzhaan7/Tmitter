using Tmitter.Application.Common.Interfaces.Repositories;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance.Repositories;

public class HashtagRepository : Repository<Hashtag>, IHashtagRepository
{
    public HashtagRepository(TmitterDbContext context) : base(context)
    {
    }
}
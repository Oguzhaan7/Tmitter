using Tmitter.Application.Common.Interfaces.Repositories;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance.Repositories;

public class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(TmitterDbContext context) : base(context)
    {
    }
}
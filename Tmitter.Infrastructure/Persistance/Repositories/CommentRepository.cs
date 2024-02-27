using Tmitter.Application.Common.Interfaces.Repositories;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance.Repositories;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(TmitterDbContext context) : base(context)
    {
    }
}
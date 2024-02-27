using Tmitter.Application.Common.Interfaces.Repositories;
using Tmitter.Domain;

namespace Tmitter.Infrastructure.Persistance.Repositories;

public class MessageRepository : Repository<Message>, IMessageRepository
{
    public MessageRepository(TmitterDbContext context) : base(context)
    {
    }
}
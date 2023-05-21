using AutoMapper;
using tatoulink.DataAccess.EfModels;

namespace tatoulink.DataAccess.Repositories
{
    public class NotificationRepository : Repository<EfModels.Notification, Dbo.Notification>, Interfaces.INotificationRepository
    {
        public NotificationRepository(EfModels.DbContext context, ILogger logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}

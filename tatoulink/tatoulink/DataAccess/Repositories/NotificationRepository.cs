using AutoMapper;
using tatoulink.DataAccess.EfModels;

namespace tatoulink.DataAccess.Repositories
{
    public class NotificationRepository : Repository<EfModels.Notification, Dbo.Notification>, Interfaces.INotificationRepository
    {
        public NotificationRepository(DbContext context, ILogger<NotificationRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}

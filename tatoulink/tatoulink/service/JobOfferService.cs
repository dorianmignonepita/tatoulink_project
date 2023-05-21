using System.Linq;
using NuGet.Protocol.Core.Types;
using tatoulink.DataAccess;
using tatoulink.DataAccess.EfModels;
using tatoulink.DataAccess.Interfaces;
using tatoulink.Dbo;

namespace tatoulink.service
{
    public class JobOfferService
    {
        private readonly IJobOfferUserRepository _jobOfferUserRepository;
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IUserRepository _userRepository;
        private INotificationRepository _notificationRepository;

        public JobOfferService(IJobOfferRepository jobOfferRepository, IJobOfferUserRepository jobOfferUserRepository, IUserRepository userRepository, INotificationRepository notificationRepository)
        {
            _jobOfferRepository = jobOfferRepository;
            _userRepository = userRepository;
            _jobOfferUserRepository = jobOfferUserRepository;
            _notificationRepository = notificationRepository;
        }
        public async Task<IEnumerable<Dbo.JobOffer>> GetAllJobOffer()
        {
            return await _jobOfferRepository.Get();
        }

        public async Task<IEnumerable<Dbo.User>> GetAllUser()
        {
            return await _userRepository.Get();
        }

        public async Task<IEnumerable<Dbo.JobOfferUser>> GetAllJobOfferUser()
        {
            return await _jobOfferUserRepository.Get();
        }

        public async Task<IEnumerable<int?>> GetAllPostulant(int JobOfferId)
        {
            var list = await _jobOfferUserRepository.Get();
            return list.Where(jobOfferUser => jobOfferUser.JobOfferId ==  JobOfferId).Select(JobOffer => JobOffer.UserId); 
        }

        public async Task<IEnumerable<int?>> GetAllJobOfferPostulated(int userId)
        {
            var list = await _jobOfferUserRepository.Get();
            return list.Where(jobOfferUser => jobOfferUser.UserId == userId).Select(jobOffer => jobOffer.JobOfferId);
        }
        public async Task<Dbo.JobOffer> GetJobOffer(int? id)
        {
            var list = await _jobOfferRepository.Get();
            return list.Where(JobOffer => JobOffer.Id == id).First();
        }

        public async Task<Dbo.User> GetUser(int id)
        {
            var list = await _userRepository.Get();
            return list.Where(user => user.Id == id).First();
        }

        public async Task<Dbo.JobOfferUser> GetJobOfferUser(int? id)
        {
            var list = await _jobOfferUserRepository.Get();
            return list.Where(jobOfferUser => jobOfferUser.Id == id).First();
        }

        public async Task AddNotification(Dbo.Notification notification)
        {
            await _notificationRepository.Insert(notification);
        }

        public async Task ApplyToJobOffer(Dbo.JobOffer jobOffer, Dbo.User user)
        {
            var jobOfferUser = new Dbo.JobOfferUser
            {
                JobOfferId = jobOffer.Id,
                UserId = user.Id
            };
            var notificationCreator = new Dbo.Notification
            {
                SenderId = user.Id,
                ReceiverId = jobOffer.CreatorId,
                JobOfferUserId = jobOfferUser.Id,
                Message = "Un utilisateur a postulé à votre offre d'emploi: /Users/Details/" + user.Id,
                Timestamp = DateTime.Now,  
            };

            var notificationPostulant = new Dbo.Notification
            {
                SenderId = jobOffer.CreatorId,
                ReceiverId = user.Id,
                JobOfferUserId = jobOfferUser.Id,
                Message = "Vous avez postulé à l'offre d'emploi: /JobOffers/Details/" + jobOffer.Id,
                Timestamp = DateTime.Now,
            };

            await _jobOfferUserRepository.Insert(jobOfferUser);
            await _notificationRepository.Insert(notificationCreator); 
            await _notificationRepository.Insert(notificationPostulant);
        }

        public async Task<IEnumerable<Dbo.Notification>> GetNotificationOfUser(int UserId)
        {
            var list = await _notificationRepository.Get();
            return list.Where(notification => notification.ReceiverId == UserId);
        }

        public async Task<IEnumerable<Dbo.Notification>> GetNotificationOfJobOffer(int jobOfferID)
        {
            var listJobOfferUser = await _jobOfferUserRepository.Get();
            var listNotification = await _notificationRepository.Get();
            var listJobOfferMatching = listJobOfferUser.Where(JobOfferUser => JobOfferUser.JobOfferId == jobOfferID).Select(JobOfferUser => JobOfferUser.UserId);
            return listNotification.Where(notification => listJobOfferMatching.Any(userId => userId == notification.ReceiverId));
        }

        public async Task DeleteJobOffer(Dbo.JobOffer jobOffer)
        {
            var list = await GetNotificationOfJobOffer(jobOffer.Id);
            var nothing = list.Select(async notification => {
                var notificationPostulant = new Dbo.Notification
                {
                    SenderId = notification.SenderId,
                    ReceiverId = notification.ReceiverId,
                    JobOfferUserId = 0,
                    Message = "une offre a été supprimé!",
                    Timestamp = DateTime.Now,
                };
                await _jobOfferUserRepository.Delete(notification.JobOfferUserId);
                await _notificationRepository.Insert(notificationPostulant);
                await _notificationRepository.Delete(notification.Id);
                });
            await _jobOfferRepository.Delete(jobOffer.Id);
        }
    }
}

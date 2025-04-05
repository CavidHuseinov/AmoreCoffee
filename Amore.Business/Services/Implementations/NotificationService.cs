using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Services.Interfaces;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Interfaces;

namespace Amore.Business.Services.Implementations
{
    public class NotificationService : INotificationService
    {
            private readonly INotificationRepository _notificationRepository;

            public NotificationService(INotificationRepository notificationRepository)
            {
                _notificationRepository = notificationRepository;
            }

            public async Task AddNotificationAsync(string name, string email, string comment)
            {
                var notification = new Notification
                {
                    Name = name,
                    Email = email,
                    Comment = comment,
                    CreatedAt = DateTime.UtcNow
                };

                await _notificationRepository.AddNotificationAsync(notification);
            }

            public async Task<List<Notification>> GetUnreadNotificationsAsync(int limit = 30)
            {
                return await _notificationRepository.GetUnreadNotificationsAsync(limit);
            }

            public async Task MarkNotificationAsReadAsync(Guid notificationId)
            {
                await _notificationRepository.MarkAsReadAsync(notificationId);
            }

    }
}

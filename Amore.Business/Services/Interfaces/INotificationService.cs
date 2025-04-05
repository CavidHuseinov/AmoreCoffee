using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Interfaces;

namespace Amore.Business.Services.Interfaces
{
    public interface INotificationService
    {
        Task AddNotificationAsync(string name, string email, string comment);
        Task<List<Notification>> GetUnreadNotificationsAsync(int limit = 30);
        Task MarkNotificationAsReadAsync(Guid notificationId);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities;

namespace Amore.DAL.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        Task AddNotificationAsync(Notification notification);
        Task<List<Notification>> GetUnreadNotificationsAsync(int limit = 30);
        Task MarkAsReadAsync(Guid notificationId);
    }
}

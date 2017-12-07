using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Service.Models;

namespace Api.Service.Dal
{
    public interface IVisualNotificationClient
    {
        Task VisualNotification(string color);
    }
}
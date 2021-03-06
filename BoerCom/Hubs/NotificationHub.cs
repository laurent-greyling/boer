﻿using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace BoerCom.Hubs
{
    [HubName("BoerHub")]
    public class NotificationHub : Hub
    {
        public void NotifyAll(string message)
        {
            Console.WriteLine(message);
            Clients.All.BroadCastAll(message);
        }
    }
}

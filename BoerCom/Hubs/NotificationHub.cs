using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace BoerCom.Hubs
{
    [HubName("BoerHub")]
    public class NotificationHub : Hub
    {
        public void NotifyAll(string name, string message)
        {
            Clients.All.broadCastAll(name, message);
        }
    }
}

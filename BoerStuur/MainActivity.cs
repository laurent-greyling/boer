using System;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Microsoft.AspNet.SignalR.Client;

namespace BoerStuur
{
    [Activity(Label = "BoerStuur", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private HubConnection _chatConnection;
        private IHubProxy _signalRChatHub;
        public event EventHandler<string> OnMessageReceived;

        protected override async void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            _chatConnection = new HubConnection("http://169.254.80.80:8080/");
            _signalRChatHub = _chatConnection.CreateHubProxy("BoerHub");

            _signalRChatHub.On<string>("broadCastAll", message =>
            {
                OnMessageReceived?.Invoke(this, $"{message}");
            });

            await JoinChat();
            Chat("Stuur");
        }

        public virtual async Task JoinChat()
        {
            try
            {
                await _chatConnection.Start();
            }
            catch (Exception)
            {
                // TODO Do some error handling.
            }
        }

        public virtual async void Chat(string phoneChatMessage)
        {
            if (_chatConnection.State == ConnectionState.Connected)
                await _signalRChatHub.Invoke("NotificationHub", phoneChatMessage);
        }
    }

}


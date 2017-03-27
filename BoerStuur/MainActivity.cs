using System;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Widget;
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

            _chatConnection = new HubConnection("http://10.0.2.2:8080/");
            _signalRChatHub = _chatConnection.CreateHubProxy("BoerHub");

            _signalRChatHub.On<string>("BroadCastAll", message =>
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
                Toast.MakeText(this, "Connecting to server", ToastLength.Long).Show();
                await _chatConnection.Start();
                Toast.MakeText(this, $"Connection State {_chatConnection.State}", ToastLength.Long).Show();
            }
            catch (Exception ex)
            {
                // TODO Do some error handling.
                Toast.MakeText(this, $"Connection State {ex.Message}", ToastLength.Long).Show();
            }
        }

        public virtual async void Chat(string phoneChatMessage)
        {
            try
            {
                if (_chatConnection.State != ConnectionState.Connected) return;

                Toast.MakeText(this, $"Sending {phoneChatMessage}", ToastLength.Long).Show();
                await _signalRChatHub.Invoke("NotifyAll", phoneChatMessage);
            }
            catch (Exception ex)
            {
                // TODO Do some error handling.
                Toast.MakeText(this, $"Connection State {ex.Message}", ToastLength.Long).Show();
            }
            
        }
    }

}


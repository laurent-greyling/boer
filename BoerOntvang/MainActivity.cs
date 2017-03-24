using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.AspNet.SignalR.Client;

namespace BoerOntvang
{
    [Activity(Label = "BoerOntvang", MainLauncher = true, Icon = "@drawable/icon")]
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

            var messages = FindViewById<ListView>(Resource.Id.ChatMessages);

            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, new List<string>());
            messages.Adapter = adapter;
            OnMessageReceived += (sender, message) => RunOnUiThread(() =>
            adapter.Add(message));

            Chat();
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

        public virtual async void Chat()
        {
            if (_chatConnection.State == ConnectionState.Connected)
                await _signalRChatHub.Invoke("NotificationHub");
        }
    }
}


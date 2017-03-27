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

            _chatConnection = new HubConnection("http://10.0.2.2:8080/");
            _signalRChatHub = _chatConnection.CreateHubProxy("BoerHub");

            _signalRChatHub.On<string>("BroadCastAll", message =>
            {
                OnMessageReceived?.Invoke(this, $"{message}");
            });

            await JoinChat();
            
            var messages = FindViewById<ListView>(Resource.Id.ChatMessages);

            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, new List<string>());
            messages.Adapter = adapter;
            OnMessageReceived += (sender, message) => RunOnUiThread(() =>
            adapter.Add(message));

            Chat("Ontvang");
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

        public virtual async void Chat(string message)
        {
            try
            {
                if (_chatConnection.State != ConnectionState.Connected) return;
                Toast.MakeText(this, $"{message}", ToastLength.Long).Show();
                await _signalRChatHub.Invoke("NotifyAll", message);
            }
            catch (Exception ex)
            {
                //TODO do something with exception
                Toast.MakeText(this, $"Connection State {ex.Message}", ToastLength.Long).Show();
            }
        }
    }
}


using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using BoerNotify.Helpers;
using Firebase;
using Firebase.Iid;

namespace BoerNotify
{
    [Activity(Label = "BoerNotify", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private readonly GooglePlayServices _playServices;

        public MainActivity()
        {
            _playServices = new GooglePlayServices(this);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug(Tags.IntentInfo, $"Key: {key} Value: {value}");
                }
            }

            _playServices.MsgText = FindViewById<TextView>(Resource.Id.msgText);
            _playServices.IsPlayServicesAvailable();

            // Only to get the token for testing, can be removed after the fact
            var logTokenButton = FindViewById<Button>(Resource.Id.logTokenButton);
            logTokenButton.Click += delegate
            {
                //_playServices.MsgText.Text = FirebaseInstanceId.Instance.Token;
                Log.Debug(Tags.MyFirebaseIidService, $"InstanceID token: {FirebaseInstanceId.Instance.Token}");
            };
        }
    }
}


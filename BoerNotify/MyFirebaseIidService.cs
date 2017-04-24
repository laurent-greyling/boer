using System;
using Android.App;
using Firebase.Iid;
using Android.Util;


namespace BoerNotify.Helpers
{
    [Service]
    [IntentFilter(new []{ "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIidService : FirebaseInstanceIdService
    {
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(Tags.MyFirebaseIidService, "Refreshed token: " + refreshedToken);
            SendRegistrationToServer(refreshedToken);
        }

        private static void SendRegistrationToServer(string token)
        {
            // Add custom implementation, as needed.
        }
    }
}
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
        const string TAG = "MyFirebaseIIDService";
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "Refreshed token: " + refreshedToken);
            SendRegistrationToServer(refreshedToken);
        }

        private static void SendRegistrationToServer(string token)
        {
            // Add custom implementation, as needed.
        }
    }
}
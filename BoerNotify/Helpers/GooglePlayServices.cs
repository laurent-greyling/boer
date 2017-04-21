using Android.Gms.Common;
using Android.Widget;

namespace BoerNotify.Helpers
{
    public class GooglePlayServices
    {
        public TextView MsgText;
        private readonly MainActivity _mainActivity;

        public GooglePlayServices(MainActivity mainActivity)
        {
            _mainActivity = mainActivity;
        }

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(_mainActivity);

            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    MsgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                }
                else
                {
                    MsgText.Text = "Device not supported";

                }
                return false;
            }

            MsgText.Text = "Google Play Services is available.";
            return true;
        }
    }
}
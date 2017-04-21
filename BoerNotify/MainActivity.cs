using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using BoerNotify.Helpers;

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
            _playServices.MsgText = FindViewById<TextView>(Resource.Id.msgText);
            _playServices.IsPlayServicesAvailable();
        }
    }
}


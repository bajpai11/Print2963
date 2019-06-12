using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Plugin.Permissions;
using Prism;
using Prism.Ioc;
using System;

namespace PrintingApp.Droid
{
    [Activity(Label = "PrintingApp", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private int REQUEST_STORAGE = 101;
        private String TAG = "MAIN";
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));

            if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.WriteExternalStorage))
            {
                // Provide an additional rationale to the user if the permission was not granted
                // and the user would benefit from additional context for the use of the permission.
                // For example if the user has previously denied the permission.
                Log.Info("TAG", "Displaying camera permission rationale to provide additional context.");

                var requiredPermissions = new String[] { Manifest.Permission.WriteExternalStorage };
                ActivityCompat.RequestPermissions(this, requiredPermissions, REQUEST_STORAGE);
                //Snackbar.Make(layout,
                //               Resource.String.permission_location_rationale,
                //               Snackbar.LengthIndefinite)
                //        .SetAction(Resource.String.ok,
                //                   new Action<View>(delegate (View obj) {
                //                       ActivityCompat.RequestPermissions(this, requiredPermissions, REQUEST_LOCATION);
                //                   }
                //        )
                //).Show();
            }
            else
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.WriteExternalStorage, Manifest.Permission.ReadExternalStorage }, REQUEST_STORAGE);
            }


        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == REQUEST_STORAGE)
            {
                // Received permission result for camera permission.
                Log.Info(TAG, "Received response for STORAGE permission request.");

                // Check if the only required permission has been granted
                if ((grantResults.Length == 1) && (grantResults[0] == Permission.Granted))
                {
                    // Location permission has been granted, okay to retrieve the location of the device.
                    Log.Info(TAG, "STORAGE permission has now been granted.");
                    //  Snackbar.Make(layout, Resource.String.permission_available_camera, Snackbar.LengthShort).Show();
                }
                else
                {
                    Log.Info(TAG, "STORAGE permission was NOT granted.");
                    // Snackbar.Make(layout, Resource.String.permissions_not_granted, Snackbar.LengthShort).Show();

                    var requiredPermissions = new String[] { Manifest.Permission.WriteExternalStorage };
                    ActivityCompat.RequestPermissions(this, requiredPermissions, REQUEST_STORAGE);
                }
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }


        }

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        //{
        //    PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        //{
        //    global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }

    public class AndroidInitializer : IPlatformInitializer
     {
      public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PrintingApp.Droid
{

    [Activity(Label = "PrintingApp", Theme = "@style/ThemeSplash", Icon = "@drawable/iconn", MainLauncher = true, NoHistory = true)]
    public class SplasActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            StartActivity(typeof(MainActivity));
        }
      
    }
}
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
using Plugin.CurrentActivity;
using PrintingApp.Droid.Services;
using PrintingApp.Interface;

[assembly: Xamarin.Forms.Dependency(typeof(AppPaymentService))]

namespace PrintingApp.Droid.Services
{
    public class AppPaymentService : IAppPaymentService
    {
        //public string BhimPay(string amount)
        //{

        //    Intent intent = new Intent(nameof(BhimPayActivity));
        //    intent = new Intent(CrossCurrentActivity.Current.Activity, typeof(BhimPayActivity));
        //    intent.PutExtra("amount", amount);
        //    intent.AddFlags(ActivityFlags.ClearTop);
        //    CrossCurrentActivity.Current.Activity.StartActivity(intent);
        //    return "";
        //}

        //public string GooglePay(string amount)
        //{
        //    Intent intent = new Intent(nameof(GooglePayActivity));
        //    intent = new Intent(CrossCurrentActivity.Current.Activity, typeof(GooglePayActivity));
        //    intent.PutExtra("amount", amount);
        //    intent.AddFlags(ActivityFlags.ClearTop);
        //    CrossCurrentActivity.Current.Activity.StartActivity(intent);
        //    return "";
        //}

        public string IciciPay(string amount)
        {
            return "";
        }

        //public string PayTm(string amount)
        //{

        //    Intent intent = new Intent(nameof(PayTmActivity));
        //    intent = new Intent(CrossCurrentActivity.Current.Activity, typeof(PayTmActivity));
        //    intent.PutExtra("amount", amount);
        //    intent.AddFlags(ActivityFlags.ClearTop);
        //    CrossCurrentActivity.Current.Activity.StartActivity(intent);
        //    return "";
        //}

        public string PhonePay(string amount)
        {
            Intent intent = new Intent(nameof(PhonePeActivity));
            intent = new Intent(CrossCurrentActivity.Current.Activity, typeof(PhonePeActivity));
            intent.PutExtra("amount", amount);
            intent.AddFlags(ActivityFlags.ClearTop);
            CrossCurrentActivity.Current.Activity.StartActivity(intent);
            return "";
        }
    }
}
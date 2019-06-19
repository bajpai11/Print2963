using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Java.IO;
using Plugin.CurrentActivity;
using PrintingApp.Droid.Services;
using PrintingApp.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndroid))]

namespace PrintingApp.Droid.Services
{
    public class SaveAndroid : ISave
    {
        public async Task SaveTextAsync(string fileName, String contentType, MemoryStream s)
        {
            string root = null;
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            root = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).Path;
            Java.IO.File myDir = new Java.IO.File(root);
            myDir.Mkdir();

            Java.IO.File file = new Java.IO.File(myDir, fileName);

            if (file.Exists()) file.Delete();

            try
            {
                FileOutputStream outs = new FileOutputStream(file);
                outs.Write(s.ToArray());

                outs.Flush();
                outs.Close();

            }
            catch (Exception e)
            {

            }
            if (file.Exists())
            {
                Android.Net.Uri path = Android.Net.Uri.FromFile(file);
               


               // Java.IO.File file = new Java.IO.File(path);

                file.SetReadable(true);
                Android.Net.Uri uri = FileProvider.GetUriForFile(Forms.Context as Context, Forms.Context.ApplicationContext.PackageName + ".fileprovider", file);

                Intent intent = new Intent(Intent.ActionView);
                intent.SetDataAndType(uri, "application/pdf");
                intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                intent.AddFlags(ActivityFlags.NoHistory);
                intent.AddFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);

                CrossCurrentActivity.Current.AppContext.StartActivity(intent);
            }
        }
    }

}
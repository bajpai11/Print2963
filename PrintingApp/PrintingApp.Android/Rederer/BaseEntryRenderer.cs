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
using PrintingApp.Droid.Rederer;
using PrintingApp.Interface;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BaseEntry), typeof(BaseEntryRenderer))]
namespace PrintingApp.Droid.Rederer
{
    public class BaseEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var base_entry = Element as BaseEntry;

            if (Control != null && base_entry != null)
            {

                SetReturnType(base_entry);

                // Editor Action is called when the return button is pressed
                Control.EditorAction += (object sender, TextView.EditorActionEventArgs args) =>
                {
                   // if (base_entry?.ReturnType != ReturnType.Next)
                        base_entry?.Unfocus();

                    // Call all the methods attached to base_entry event handler Completed
                    base_entry?.InvokeCompleted();
                };
            }
        }

        void SetReturnType(BaseEntry entry)
        {
            var type = entry.ReturnType;

            switch (type)
            {
                //case ReturnType.Go:
                //    Control.ImeOptions = ImeAction.Go;
                //    Control.SetImeActionLabel("Go", ImeAction.Go);
                //    break;
                //case ReturnType.Next:
                //    Control.ImeOptions = ImeAction.Next;
                //    Control.SetImeActionLabel("Next", ImeAction.Next);
                //    break;
                //case ReturnType.Send:
                //    Control.ImeOptions = ImeAction.Send;
                //    Control.SetImeActionLabel("Send", ImeAction.Send);
                //    break;
                //case ReturnType.Search:
                //    Control.ImeOptions = ImeAction.Search;
                //    Control.SetImeActionLabel("Search", ImeAction.Search);
                //    break;
                //default:
                //    Control.ImeOptions = ImeAction.Done;
                //    Control.SetImeActionLabel("Done", ImeAction.Done);
                //    break;
            }
        }
    }
}
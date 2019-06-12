using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PrintingApp.Interface
{
    public class BaseEntry : Entry
    {
        // Need to overwrite default handler because we cant Invoke otherwise
        public new event EventHandler<EventArgs> Completed;

        public static readonly BindableProperty ReturnTypeProperty =
            BindableProperty.Create<BaseEntry, ReturnType>(s => s.ReturnType, ReturnType.Done);

        public ReturnType ReturnType
        {
            get { return (ReturnType)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }

        public void InvokeCompleted()
        {
            this.Completed?.Invoke(this, null);
        }
    }

    public enum ReturnType
    {
        Go,
        Next,
        Done,
        Send,
        Search
    }
}

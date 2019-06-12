using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace PrintingApp
{
    public class BehaviorEntryvalid : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
        }
        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            var email = e.NewTextValue;
            var emailpattern = "^[A-Za-z0-9][_A-Z-a-z0-9.!#$%&'*+-=?^`{|}~\\/]*@([[A-Za-z]{1,5}).([a-z]{2,4})$";
            var emailEntry = sender as Entry;
            if (Regex.IsMatch(email, emailpattern))
            {
                // ErrorLabel.Text = "Email is valid";
                emailEntry.BackgroundColor = Color.Red;
            }
            else
            {
                // ErrorLabel.Text = "Email is not valid";
                emailEntry.BackgroundColor = Color.Blue;

            }
        }
    }
}

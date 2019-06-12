using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PrintingApp.Models
{
   public class CountryModel
    {
        public string CountryName { get; set; }

        public DelegateCommand CountrySelectedCommand => new DelegateCommand(() =>
        {

            MessagingCenter.Send<CountryModel>(this, "Message");
        });
        public DelegateCommand CountrybookSelectedCommand => new DelegateCommand(() =>
        {

            MessagingCenter.Send<CountryModel>(this, "BookCountry");
        });
    }
}

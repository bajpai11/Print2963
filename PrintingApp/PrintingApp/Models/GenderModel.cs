using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PrintingApp.Models
{
   public class GenderModel
    {
        //public string GenderName { get; set; }
        //public DelegateCommand GenderSelectedCommand = new DelegateCommand(() =>
        //{
        //    MessagingCenter.Send<GenderModel>(this, "Gender");
        //});
        public string GenderName { get; set; }
        public DelegateCommand GenderSelectedCommand => new DelegateCommand(() =>
        {

            MessagingCenter.Send<GenderModel>(this, "Message");
        });
    }
}

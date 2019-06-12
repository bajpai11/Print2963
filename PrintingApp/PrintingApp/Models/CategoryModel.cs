using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PrintingApp.Models
{
   public class CategoryModel
    {
        public string DomainName { get; set; }
        public string CategoryName { get; set; }
        public string IDtypeName { get; set; }

        public DelegateCommand DomainSelectedCommand => new DelegateCommand(() =>
        {

            MessagingCenter.Send<CategoryModel>(this, "Message");

        });
        
        public DelegateCommand IDtypeSelectedCommand => new DelegateCommand(() =>
         {
             MessagingCenter.Send<CategoryModel>(this, "IDTYPE");
         });
        public DelegateCommand IDbookSelectedCommand => new DelegateCommand(() =>
        {
            MessagingCenter.Send<CategoryModel>(this, "IDbookTYPE");
        });
        public DelegateCommand CategorySelectedCommand => new DelegateCommand(() =>
        {
            MessagingCenter.Send<CategoryModel>(this, "Category");
        });
    }
}

using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace PrintingApp.Views
{
    public partial class RegistrationPage : ContentPage
    {
      //  public ICommand ScanCommand { get; set; }
      //  public ICommand BackCommand { get; set; }
        public RegistrationPage(string name, string email, string company, string mobile, string IDType)
        {
            // ScanCommand = new Command(Scan_Tap);
           
            InitializeComponent();

          //  BackCommand = new Command(Back_Tap);
            textemail.Text = email;
            textname.Text = name;
            textMobile.Text = mobile;
            textCompany.Text = company;
           
            textIDType.Text = IDType;
       //     imageName.Source = imgName;
            //  ListMethod();
            

           
            var Entryvalue = email;
         //  BarcodeImageView.BarcodeValue = $"Email:-{textemail.Text}, Mobile No.:-{textCompany.Text}, Name:{textname.Text}";
            QRcodeImageView.BarcodeValue = App.Current.Properties["Passcode"].ToString();
            QRcodeImageView.IsVisible = true;

           //  BarcodeImageView.BarcodeValue = $"{textMobile.Text},{textIDType.Text},{textCompany.Text}";
              BarcodeImageView.BarcodeValue = App.Current.Properties["Barcodee"].ToString();

            BarcodeImageView.IsVisible = true;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage=new NavigationPage(new MainPage());
        }


        //public async void Generate_Barcode(object sender, EventArgs e)
        //{

        // };

        //}
    }
}

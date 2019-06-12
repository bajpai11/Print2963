using IAudioXamarin.Validations;
using PrintingApp.Helper;
using PrintingApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrintingApp.ViewModels
{
	public class LoginPageViewModel : ModelBase, INotifyPropertyChanged
	{
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SubmitCommand { get; set; }
        public ICommand ResisterCommand { get; set; }
        public ICommand Forgot { get; set; }
        public ICommand tap { get; set; }
        private string _Username = "";

        [RegularExpression(@"^[A-Za-z0-9][_A-Z-a-z0-9.!#$%&'*+-=?^`{|}~\\/]*@([[A-Za-z]{1,5})\.([a-z]{2,4})$", ErrorMessage = "*Please enter valid email Address.")]

        [Required(AllowEmptyStrings = false, ErrorMessage = "*Please enter email")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "*Please enter a valid email id.")]
        [Display(Name = "Enter email")]

        public string Username
        {
            get { return _Username; }
            set
            {
                _Username = value;
                ValidateProperty(value);
                OnPropertyChanged(nameof(Username));
            }
        }
        private string _Password = "";
        [RegularExpression(@"^.*(?=.{8,16})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "*Please enter valid password ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Please enter password")]
        [Display(Name = "Enter Password")]

        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                ValidateProperty(value);
                OnPropertyChanged(nameof(Password));
            }

        }
        public LoginPageViewModel()
        {

            SubmitCommand = new Command(Login_Tap);
            ResisterCommand = new Command(Register_Tap);
            tap = new Command(tap_click);
            Forgot = new Command(Forgot_Tap);
        }
        private void Forgot_Tap(object obj)
        {
           // App.Current.MainPage = new NavigationPage(new RegistrationPage());
        }
        private void Register_Tap(object obj)
        {
           // App.Current.MainPage = new NavigationPage(new RegistrationPage());

        }
        private void Login_Tap(object obj)
        {
            //bool IsPasscode1null = StringHelper.IsEmpty(Username);
            //bool IsPasscode2null = StringHelper.IsEmpty(Password);
          
            //var Passcode = Username + Password;
            //App.Current.Properties["Passcode"] = Passcode;
            if (IsValidate(_Username, "Username"))
            {
                if (IsValidate(_Password, "Password"))
                {
                    App.Current.MainPage = new NavigationPage(new DashBoardScreen());
                }
                else
                {
                    //  UserDialogs.Instance.Alert(PathUtils.Internet);
                    App.Current.MainPage.DisplayAlert("Alert", "Please enter valid password", "OK");
                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alert", "Please enter valid Email", "OK");
            }
            //App.Current.MainPage.Navigation.PushAsync(new LandingPage());


        }
        private ImageSource _img = "un.png";

        public ImageSource img
        {
            get { return _img; }
            set { _img = value; }
        }
        int count1 = 0;
        private void tap_click()
        {
            if (count1 == 0)
            {
                _img = "untick.png";
                OnPropertyChanged("img");
                count1 = 1;
            }
            else
            {
                _img = "un.png";
                OnPropertyChanged("img");
                count1 = 0;
            }
        }
    }
}

using PrintingApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrintingApp.ViewModels
{
	public class RegistrationPageViewModel : BindableBase
	{
        private readonly INavigationService _navigationService;
        public ICommand BackCommand { get; set; }

        public RegistrationPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            BackCommand = new Command(Back_Tap);

        }
        private async void Back_Tap(object obj)
        {
            App.Current.MainPage = new NavigationPage(new DashBoardScreen());
        }

    }
}

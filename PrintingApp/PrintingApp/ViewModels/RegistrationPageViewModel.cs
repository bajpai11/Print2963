using PrintingApp.Services;
using PrintingApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrintingApp.ViewModels
{
	public class RegistrationPageViewModel : BindableBase
	{
        private readonly INavigationService _navigationService;
        public ICommand BackCommand { get; set; }
        public ICommand PrintCommand { get; set; }

        public RegistrationPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _blueToothService = DependencyService.Get<IBlueToothService>();
            BindDeviceList();
            BackCommand = new Command(Back_Tap);
            PrintCommand = new Command(Print_Tap);
        }

        private readonly IBlueToothService _blueToothService;

        private IList<string> _deviceList;
        public IList<string> DeviceList
        {
            get
            {
                if (_deviceList == null)
                    _deviceList = new ObservableCollection<string>();
                return _deviceList;
            }
            set
            {
                _deviceList = value;
            }
        }

        private string _printMessage;
        public string PrintMessage
        {
            get
            {
                return _printMessage;
            }
            set
            {
                _printMessage = value;
            }
        }

        private string _selectedDevice;
        public string SelectedDevice
        {
            get
            {
                return _selectedDevice;
            }
            set
            {
                _selectedDevice = value;
            }
        }
        private async void Back_Tap(object obj)
        {
            App.Current.MainPage = new NavigationPage(new DashBoardScreen());
        }
        private async void Print_Tap(object obj)
        {
            //PrintMessage += " Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            //  await _blueToothService.Print(SelectedDevice, PrintMessage);
            //   await _navigationService.NavigateAsync("DashBoardScreen");
         //  App.Current.MainPage = new NavigationPage(new TicketPrintScreen());
        }
        void BindDeviceList()
        {
            var list = _blueToothService.GetDeviceList();
            DeviceList.Clear();
            foreach (var item in list)
                DeviceList.Add(item);
        }
    }
}

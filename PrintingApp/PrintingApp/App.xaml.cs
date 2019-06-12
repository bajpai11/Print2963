using Prism;
using Prism.Ioc;
using PrintingApp.ViewModels;
using PrintingApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrintingApp
{
    public partial class App
    {
        public static App CurrentApp
        {
            get { return (App)App.Current; }
        }
        public string BarCodeResult { get; set; }
        static LiteDBHelper db;
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }
        public static LiteDBHelper LiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new LiteDBHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamarinLiteDB.db"));
                }
                return db;
            }
        }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/DashBoardScreen");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<RegistrationPage, RegistrationPageViewModel>();
            containerRegistry.RegisterForNavigation<DashBoardScreen, DashBoardScreenViewModel>();
            containerRegistry.RegisterForNavigation<TicketPrintScreen, TicketPrintScreenViewModel>();
          
        }
    }
}

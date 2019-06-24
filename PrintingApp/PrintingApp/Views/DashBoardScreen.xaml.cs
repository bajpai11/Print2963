using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using PrintingApp.Common;
using PrintingApp.Helper;
using PrintingApp.Interface;
using PrintingApp.Models;
using PrintingApp.ViewModels;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace PrintingApp.Views
{
    public partial class DashBoardScreen : ExtendedTabbedPage
    {
        public DashBoardScreen()
        {
            InitializeComponent();
            this.SelectedItem = this.Children[0];

            var personList = App.LiteDB.GetAllPersons();
            if (personList.Count != 0)
            {
                //lstPersons.ItemsSource = personList;
            }

          

            MessagingCenter.Subscribe<DashBoardScreenViewModel>(this, "Message", async (args) =>
            {

                bool IsPasscode1null = StringHelper.IsEmpty(txtName.Text);
                bool IsPasscode2null = StringHelper.IsEmpty(txtEmail.Text);
                bool IsPasscode3null = StringHelper.IsEmpty(txtMobile.Text);
                bool IsPasscode4null = StringHelper.IsEmpty(txtCompany.Text);
                bool IsPasscode5null = StringHelper.IsEmpty(txtIDtype.Text);

                 var QRCode = $"{txtEmail.Text}, {txtCompany.Text}, {txtName.Text}, {txtMobile.Text}, {txtIDtype.Text}";
                var BarCode = $"{txtIDtype.Text}";
                // var keycode = $"{"a"}";
                App.Current.Properties["Passcode"] = QRCode;
                App.Current.Properties["Barcodee"] = BarCode;
                //App.Current.Properties["key"] = keycode;
                App.Current.MainPage = new NavigationPage(new RegistrationPage(txtName.Text, txtEmail.Text, txtMobile.Text, txtCompany.Text, txtIDtype.Text, image.Source));


                //   var bc = (DashBoardScreenViewModel) ;
                //Person person = new Person()
                //{
                   
                //    Name = txtName.Text,
                //    Email = txtEmail.Text,
                //    Mobileno = txtMobile.Text,
                //    CompanyName = txtCompany.Text,

                //    //DesignationName = txtDesignation.Text,
                //    IDTypeName = txtIDtype.Text,

                //    //    Imageimg = image.Source

                //};
                ////Add New Person
               //App.LiteDB.AddPerson(person);
                //txtName.Text = string.Empty;
                //txtEmail.Text = string.Empty;
                //txtMobile.Text = string.Empty;
                //txtCompany.Text = string.Empty;
                //// txtDesignation.Text = string.Empty;
                //txtIDtype.Text = string.Empty;
                ////    image.Source = string.Empty;
                ////  MessagingCenter.Send<RegistrationPage>(this, "txtName");
                //DisplayAlert("Success", "Person Added", "OK");

                ////Get All Persons
                //var personListt = App.LiteDB.GetAllPersons();
                //if (personListt.Count != 0)
                //{
                //    // lstPersons.ItemsSource = personListt;
                //}

            });
            MessagingCenter.Subscribe<DashBoardScreenViewModel>(this, "upload", async (args) =>
            {

                try
                {
                    var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                    if (status != PermissionStatus.Granted)
                    {
                        if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                        {
                            await DisplayAlert("Camera Permission", "Please aloow camera ermission for access camera image and get the picture", "OK");
                        }

                        var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera });
                        status = results[Permission.Camera];
                    }

                    if (status == PermissionStatus.Granted)
                    {

                        await CrossMedia.Current.Initialize();

                        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                        {
                            await DisplayAlert("No Camera", ":( No camera available.", "OK");
                            return;
                        }

                        var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                        {
                            PhotoSize = PhotoSize.Medium,

                        });

                        //if (file == null)
                        //    return;


                        //using (var memoryStream = new MemoryStream())
                        //{
                        //    file.GetStream().CopyTo(memoryStream);
                        //    var myfile = memoryStream.ToArray();
                        //    mysfile = myfile;
                        //}

                        image.Source = ImageSource.FromFile(file.Path);
                        if (file == null)
                            return;

                        DisplayAlert("File Location", file.Path, "OK");
                        image.Source = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            file.Dispose();
                            return stream;
                        });
                    }
                    else if (status != PermissionStatus.Granted)
                    {
                        await DisplayAlert("Camera Denied", "Please allow camera permission, try again.", "OK");
                    }
                }
                catch (Exception ex)
                {

                    await DisplayAlert("Error", "Camera Not Available", "OK");
                }
        });
    }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            if (CurrentPage.Title == "App")
            {
                //home.Icon = "app_logo.png";
            }
            else
            {
                //home.Icon = "app_logo_unselected.png";
            }
            this.Title = CurrentPage.Title;
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                // var CodeResult = App.Current.Properties["Passcode"].ToString();
                //  var BarCodeResult = App.Current.Properties["Barcodee"].ToString();
              

                var scan = new ZXingScannerPage();
                await Navigation.PushAsync(scan);
                scan.OnScanResult += (BarcodeValue) =>
                {
                   if (App.Current.Properties["Barcodee"].ToString() == BarcodeValue.ToString() || App.Current.Properties["Passcode"].ToString() == BarcodeValue.ToString())
                   {
                       // App.LiteDB.AddPerson();
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await Navigation.PopAsync();
                             qrLabel.Text = BarcodeValue.Text;


                            Person person = new Person()
                            {
                                Name = qrLabel.Text,
                               // Name = BarcodeValue.Text

                            // Mobileno = txtMobile.Text,
                            // CompanyName = txtCompany.Text,
                            //IDTypeName = txtIDtype.Text,

                            //    Imageimg = image.Source

                            };
                            App.LiteDB.AddPerson(person);
                            qrLabel.Text = string.Empty;
                            var personListt = App.LiteDB.GetAllPersons();
                            if (personListt.Count != 0)
                            {
                               lstPersons.ItemsSource = personListt;
                            }
                        });

                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await Navigation.PopAsync();
                           // qrLabel.Text = "QR is not valid";
                            DisplayAlert("Alert", "Invalid code", "OK");
                        });

                    }
                };
            }
            catch (Exception ex)
            {
                DisplayAlert("Alert", "Barcode value is empty", "ok");
            }
            //try
            //{
            //    var scanner = DependencyService.Get<IQrScanningService>();
            //    var result = await scanner.ScanAsync();
            //    if (result != null)
            //    {
            //        qrLabel.Text = result;
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

            });


            if (file == null)
                return;

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }
        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    var scan = new ZXingScannerPage();
        //    await Navigation.PushAsync(scan);
        //    scan.OnScanResult += (result) =>
        //    {

        //        Device.BeginInvokeOnMainThread(async () =>
        //        {
        //            await Navigation.PopAsync();
        //            EmailEntry.Text = result.Text;
        //        });
        //    };
        //}
        //private async void btnScan_Clicked(object sender, EventArgs e)
        //{
        //    var scan = new ZXingScannerPage();
        //    await Navigation.PushAsync(scan);
        //    scan.OnScanResult += (result) =>
        //    {
        //        Device.BeginInvokeOnMainThread(async () =>
        //        {
        //            await Navigation.PopAsync();
        //            //txtEmail.Text = result.Text;
        //        });
        //    };
        //}
    }
}

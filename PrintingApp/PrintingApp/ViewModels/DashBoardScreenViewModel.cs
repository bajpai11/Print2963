using IAudioXamarin.Validations;
using PrintingApp.Models;
using PrintingApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrintingApp.ViewModels
{
	
   public class DashBoardScreenViewModel : ModelBase, INotifyPropertyChanged
    {
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        int count;
        /// <summary>
        /// private 
        /// </summary>
       #region         
        private bool _pickervisible = false;
        private string _labelSelectedDomain = "Select Category";
        private string _labelSelectedbookCategory = "Select Category";
        private string _labelSelectedCountry = "Select Country";
        private string _labelSelectedGender = "Select Gender";
        private string _labelSelectedIDType = "Select ID Type";
        private string _labelSelectedbookID = "Select ID Type";
        private string _labelSelectedbookCountry = "Select Country";
        private string _lstPersons;
        private string _txtpassword;
        private string _txtemail;
        private string _txtname;
        private CategoryModel _selectedID;
        private CategoryModel _selectedbookID;
        private GenderModel _selectedgender;
        private CountryModel _selectedcountry;
        private CountryModel _selectedBookcountry;
        private CategoryModel _selectedDomain;
        private CountryModel _selectedbookcountry;
        private CategoryModel _selectedcategory;
        private bool _idbookvisible;
        private bool _countrybookvisible;
        private bool _categoryvisible;
        private bool _idtypeVisible;
        private bool _countryVisible;
        private bool _countrybookVisible=false;
        private bool _gendervisible;
        private readonly INavigationService _navigationService;
        private ObservableCollection<CategoryModel> _domainModel = new ObservableCollection<CategoryModel>();
        private ObservableCollection<GenderModel> _genderModel = new ObservableCollection<GenderModel>();
        private ObservableCollection<CountryModel> _countryModel = new ObservableCollection<CountryModel>();
        #endregion
        public ICommand BackCommand { get; set; }
        public ICommand SaveCommand { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="navigationService"></param>
        public DashBoardScreenViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            BackCommand = new Command(Back_Tap);
            SaveCommand = new Command(Save_Tap);
            SetDomainList();
            SetCountryList();
            SetGenderList();

            //var personList = App.LiteDB.GetAllPersons();
            //if (personList.Count != 0)
            //{
            //    lstPersons = personList.ToString();
            //}
          //  _blueToothService = DependencyService.Get<IBlueToothServices>();
          //  BindDeviceList();
             
            MessagingCenter.Subscribe<CategoryModel>(this, "Message", async (args1) =>
            {
                _selectedDomain = args1;
                if (SelectedDomain != null)
                {
                    //SelectedDomain.BgColor = Color.FromHex("#707070");
                    LabelSelectedDomain = SelectedDomain.DomainName;
                    Pickervisible = false;
                    int index = DomainListItem.IndexOf(DomainListItem.First(x => x.DomainName == SelectedDomain.DomainName));
                    DomainListItem.RemoveAt(index);
                    DomainListItem.Insert(index, SelectedDomain);
                }
            });


            
            MessagingCenter.Subscribe<CountryModel>(this, "Message", async (args1) =>
            {
                _selectedcountry = args1;
                if (SelectedCountry != null)
                {
                    //SelectedDomain.BgColor = Color.FromHex("#707070");
                    LabelSelectedCountry = SelectedCountry.CountryName;
                    Countryvisible = false;
                    int index = CountryListItem.IndexOf(CountryListItem.First(x => x.CountryName == SelectedCountry.CountryName));
                    CountryListItem.RemoveAt(index);
                    CountryListItem.Insert(index, SelectedCountry);
                }
            });

            MessagingCenter.Subscribe<CountryModel>(this, "BookCountry", async (args1) =>
            {
                _selectedbookcountry = args1;
                if (SelectedbookCategory != null)
                {

                    LabelSelectedbookCountry = SelectedbookCategory.CountryName;
                    Countrybookvisible = false;
                    int index = CountryListItem.IndexOf(CountryListItem.First(x => x.CountryName == SelectedbookCategory.CountryName));
                    CountryListItem.RemoveAt(index);
                    CountryListItem.Insert(index, SelectedbookCategory);
                }
            });

            MessagingCenter.Subscribe<GenderModel>(this, "Message", async (args1) =>
            {
               _selectedgender = args1;
                if (SelectedGender != null)
                {
                    //SelectedDomain.BgColor = Color.FromHex("#707070");
                    LabelSelectedGender = SelectedGender.GenderName;
                    Gendervisible = false;
                    int index = GenderListItem.IndexOf(GenderListItem.First(x => x.GenderName == SelectedGender.GenderName));
                    GenderListItem.RemoveAt(index);
                    GenderListItem.Insert(index, SelectedGender);
                }
            });
            MessagingCenter.Subscribe<CategoryModel>(this, "IDTYPE", async (args1) =>
            {
                _selectedID = args1;
                if (SelectedID != null)
                {

                    LabelSelectIDType = SelectedID.IDtypeName;
                    IDTypevisible = false;
                    int index = IDListItem.IndexOf(IDListItem.First(x => x.IDtypeName == SelectedID.IDtypeName));
                    IDListItem.RemoveAt(index);
                    IDListItem.Insert(index, SelectedID);
                }
            });
            MessagingCenter.Subscribe<CategoryModel>(this, "IDbookTYPE", async (args1) =>
            {
                _selectedbookID = args1;
                if (SelectedbookID != null)
                {

                    LabelSelectedbookID = SelectedbookID.IDtypeName;
                    IDbookvisible = false;
                    int index = IDListItem.IndexOf(IDListItem.First(x => x.IDtypeName == SelectedbookID.IDtypeName));
                    IDListItem.RemoveAt(index);
                    IDListItem.Insert(index, SelectedbookID);
                }
            });
            
            MessagingCenter.Subscribe<CategoryModel>(this, "Category", async (args1) =>
            {
                _selectedcategory = args1;
                if (SelectedCategory != null)
                {

                    LabelSelectedcategory = SelectedCategory.CategoryName;
                    Categoryvisible = false;
                    int index = CategoryListItem.IndexOf(CategoryListItem.First(x => x.CategoryName == SelectedCategory.CategoryName));
                    CategoryListItem.RemoveAt(index);
                    CategoryListItem.Insert(index, SelectedCategory);
                }
            });

        }
        /// <summary>
        /// public properties
        /// </summary>
        #region
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
        

        private string _Username = "";

        [RegularExpression(@"^[a-zA-Z]{1,20}$", ErrorMessage = "*Please enter valid Name")]

        [Required(AllowEmptyStrings = false, ErrorMessage = "*Please enter Name")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "*Please enter a valid name id.")]
        [Display(Name = "Enter email")]

        public string Username
        {
            get { return _Username; }
            set
            {
                _Username = value;
              //  ValidateProperty(value);
                OnPropertyChanged(nameof(Username));
            }
        }
        private string _textCompany;
        public string textCompany
        {
            get { return _textCompany; }
            set
            {
                _textCompany = value;
                //  ValidateProperty(value);
                OnPropertyChanged(nameof(textCompany));
            }
        }
        private string _mobileNum;
        public string MobileNum
        {
            get { return _mobileNum; }
            set
            {
                _mobileNum = value;
                 ValidateProperty(value);
                OnPropertyChanged(nameof(MobileNum));
            }
        }

        private string _entryEmail = "";

        [RegularExpression(@"^[A-Za-z0-9][_A-Z-a-z0-9.!#$%&'*+-=?^`{|}~\\/]*@([[A-Za-z]{1,5})\.([a-z]{2,4})$", ErrorMessage = "*Please enter valid email Address.")]

        [Required(AllowEmptyStrings = false, ErrorMessage = "*Please enter email")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "*Please enter a valid email id.")]
        [Display(Name = "Enter email")]

        public string EntryEmail
        {
            get { return _entryEmail; }
            set
            {
                _entryEmail = value;
                ValidateProperty(value);
                OnPropertyChanged(nameof(EntryEmail));
            }
        }

        private string _Password = "";
        //[RegularExpression(@"^.*(?=.{8,16})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "*Please enter valid password ")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "*Please enter password")]
        //[Display(Name = "Enter Password")]

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
        public string LabelSelectedDomain
        {
            get { return _labelSelectedDomain; }
            set
            {
                _labelSelectedDomain = value;
                
                OnPropertyChanged(nameof(LabelSelectedDomain));
            }
        }
        public string LabelSelectedcategory
        {
            get { return _labelSelectedbookCategory; }
            set
            {
                _labelSelectedbookCategory = value;
                OnPropertyChanged(nameof(LabelSelectedcategory));
            }
        }
        public string LabelSelectedGender
        {
            get { return _labelSelectedGender; }
            set
            {
                _labelSelectedGender = value;
                OnPropertyChanged(nameof(LabelSelectedGender));
            }
        }
        
        public string LabelSelectedCountry
        {
            get { return _labelSelectedCountry; }
            set
            {
                _labelSelectedCountry = value;
                OnPropertyChanged(nameof(LabelSelectedCountry));
            }
        }
        
        public string LabelSelectedbookCountry
        {
            get { return _labelSelectedbookCountry; }
            set
            {
                _labelSelectedbookCountry = value;
                OnPropertyChanged(nameof(LabelSelectedbookCountry));
            }
        }

        public string LabelSelectIDType
        {
            get { return _labelSelectedIDType; }
            set
            {
                _labelSelectedIDType = value;
                OnPropertyChanged(nameof(LabelSelectIDType));
            }
        }
        public string LabelSelectedbookID
        {
            get { return _labelSelectedbookID; }
            set
            {
                _labelSelectedbookID = value;
                OnPropertyChanged(nameof(LabelSelectedbookID));
            }
        }

        public bool Pickervisible
        {
            get { return _pickervisible; }
            set
            {
                _pickervisible = value;
                OnPropertyChanged(nameof(Pickervisible));
            }
        }
        public bool Categoryvisible
        {
            get { return _categoryvisible; }
            set
            {
                _categoryvisible = value;
                OnPropertyChanged(nameof(Categoryvisible));
            }
        }

        public bool Gendervisible
        {
            get { return _gendervisible; }
            set
            {
                _gendervisible = value;
                OnPropertyChanged(nameof(Gendervisible));
            }
        }
       
        public bool Countryvisible
        {
            get { return _countryVisible; }
            set
            {
                _countryVisible = value;
                OnPropertyChanged(nameof(Countryvisible));
            }
        }
        public bool CountryBookvisible
        {
            get { return _countrybookVisible; }
            set
            {
                _countrybookVisible = value;
                OnPropertyChanged(nameof(CountryBookvisible));
            }
        }
        
        public bool IDTypevisible
        {
            get { return _idtypeVisible; }
            set
            {
                _idtypeVisible = value;
                OnPropertyChanged(nameof(IDTypevisible));
            }
        }
      
        public bool IDbookvisible
        {
            get { return _idbookvisible; }
            set
            {
                _idbookvisible = value;
                OnPropertyChanged(nameof(IDbookvisible));
            }
        }
     
        public bool Countrybookvisible
        {
            get { return _countrybookvisible; }
            set
            {
                _countrybookvisible = value;
                OnPropertyChanged(nameof(Countrybookvisible));
            }
        }

        public CategoryModel SelectedDomain
        {
            get { return _selectedDomain; }
            set
            {
                _selectedDomain = value;
                if (SelectedDomain != null)
                {

                    LabelSelectedDomain = SelectedDomain.DomainName;
                    Pickervisible = false;
                    int index = DomainListItem.IndexOf(DomainListItem.First(x => x.DomainName == SelectedDomain.DomainName));
                    DomainListItem.RemoveAt(index);
                    DomainListItem.Insert(index, SelectedDomain);
                }
            }
        }
        public CategoryModel SelectedCategory
        {
            get { return _selectedcategory; }
            set
            {
                _selectedcategory = value;
                if (SelectedCategory != null)
                {

                    LabelSelectedcategory = SelectedCategory.CategoryName;
                    Categoryvisible = false;
                    int index = CategoryListItem.IndexOf(CategoryListItem.First(x => x.CategoryName == SelectedCategory.CategoryName));
                    CategoryListItem.RemoveAt(index);
                    CategoryListItem.Insert(index, SelectedCategory);
                }
            }
        }
        

        public CountryModel SelectedCountry
        {
            get { return _selectedcountry; }
            set
            {
                _selectedcountry = value;
                if (SelectedCountry != null)
                {

                    LabelSelectedCountry = SelectedCountry.CountryName;
                    Pickervisible = false;
                    int index = CountryListItem.IndexOf(CountryListItem.First(x => x.CountryName == SelectedCountry.CountryName));
                    CountryListItem.RemoveAt(index);
                    CountryListItem.Insert(index, SelectedCountry);
                }
            }
        }
        public CountryModel SelectedbookCategory
        {
            get { return _selectedbookcountry; }
            set
            {
                _selectedbookcountry = value;
                if (SelectedbookCategory != null)
                {

                    LabelSelectedCountry = SelectedbookCategory.CountryName;
                    Countrybookvisible = false;
                    int index = CountryListItem.IndexOf(CountryListItem.First(x => x.CountryName == SelectedbookCategory.CountryName));
                    CountryListItem.RemoveAt(index);
                    CountryListItem.Insert(index, SelectedbookCategory);
                }
            }
        }

        public CountryModel SelectedBookCountry
        {
            get { return _selectedBookcountry; }
            set
            {
                _selectedBookcountry = value;
                if (SelectedBookCountry != null)
                {

                    LabelSelectedbookCountry = SelectedBookCountry.CountryName;
                    CountryBookvisible = false;
                    int index = CountryBookListItem.IndexOf(CountryBookListItem.First(x => x.CountryName == SelectedBookCountry.CountryName));
                    CountryBookListItem.RemoveAt(index);
                    CountryBookListItem.Insert(index, SelectedBookCountry);
                }
            }
        }

        public GenderModel SelectedGender
        {
            get { return _selectedgender; }
            set
            {
                _selectedgender = value;
                if (SelectedGender != null)
                {

                    LabelSelectedGender = SelectedGender.GenderName;
                    Gendervisible = false;
                    int index = GenderListItem.IndexOf(GenderListItem.First(x => x.GenderName == SelectedGender.GenderName));
                    GenderListItem.RemoveAt(index);
                    GenderListItem.Insert(index, SelectedGender);
                }
            }
        }
     
        public CategoryModel SelectedID
        {
            get { return _selectedID; }
            set
            {
                _selectedID = value;
                if (SelectedID != null)
                {

                    LabelSelectIDType = SelectedID.IDtypeName;
                    IDTypevisible = false;
                    int index = IDListItem.IndexOf(IDListItem.First(x => x.IDtypeName == SelectedID.IDtypeName));
                    IDListItem.RemoveAt(index);
                    IDListItem.Insert(index, SelectedID);
                }
            }
        }
        public CategoryModel SelectedbookID
        {
            get { return _selectedbookID; }
            set
            {
                _selectedbookID = value;
                if (SelectedbookID != null)
                {

                    LabelSelectedbookID= SelectedbookID.IDtypeName;
                    IDbookvisible = false;
                    int index = IDListItem.IndexOf(IDListItem.First(x => x.IDtypeName == SelectedbookID.IDtypeName));
                    IDListItem.RemoveAt(index);
                    IDListItem.Insert(index, SelectedbookID);
                }
            }
        }
        

        public string txtName
        {
            get { return _txtname; }
            set
            {
                _txtname = value;
                OnPropertyChanged(nameof(txtName));
            }
        }
       
        public string txtEmail
        {
            get { return _txtemail; }
            set
            {
                _txtemail = value;
                OnPropertyChanged(nameof(txtEmail));
            }
        }
      
        public string txtPassword
        {
            get { return _txtpassword; }
            set
            {
                _txtpassword = value;
                OnPropertyChanged(nameof(txtPassword));
            }
        }
      
        public string lstPersons
        {
            get { return _lstPersons; }
            set
            {
                _lstPersons = value;
                OnPropertyChanged(nameof(lstPersons));
            }
        }
        public ObservableCollection<CategoryModel> DomainListItem
        {
            get { return _domainModel; }
            set
            {
                _domainModel = value;
                OnPropertyChanged(nameof(DomainListItem));
            }
        }
        public ObservableCollection<CategoryModel> CategoryListItem
        {
            get { return _domainModel; }
            set
            {
                _domainModel = value;
                OnPropertyChanged(nameof(CategoryListItem));
            }
        }

        public ObservableCollection<CountryModel> CountryListItem
        {
            get { return _countryModel; }
            set
            {
                _countryModel = value;
                OnPropertyChanged(nameof(CountryListItem));
            }
        }
        public ObservableCollection<CountryModel> CountryBookListItem
        {
            get { return _countryModel; }
            set
            {
                _countryModel = value;
                OnPropertyChanged(nameof(CountryBookListItem));
            }
        }

        public ObservableCollection<GenderModel> GenderListItem
        {
            get { return _genderModel; }
            set
            {
                _genderModel = value;
                OnPropertyChanged(nameof(GenderListItem));
            }
        }
        public ObservableCollection<CategoryModel> IDListItem
        {
            get { return _domainModel; }
            set
            {
                _domainModel = value;
                OnPropertyChanged(nameof(IDListItem));
            }
        }

        #endregion
     /// <summary>
     /// method
     /// </summary>
        private void SetGenderList()
        {
            _genderModel.Clear();
            GenderListItem = new ObservableCollection<GenderModel>
            {
                new GenderModel
                {
                    GenderName= "Male"
                },
                new GenderModel
                {
                    GenderName="Female"
                }
            }; 
            
         }

        private void SetCountryList()
        {
            _countryModel.Clear();
            CountryListItem = new ObservableCollection<CountryModel>
            {
                new CountryModel
                {
                  CountryName="India"

                },
                new CountryModel
                {
                    CountryName="USA"
                },
                 new CountryModel
                 {
                   CountryName="AUS"
                 },
                new CountryModel
                {
                   CountryName="SA"
                },
                 new CountryModel
                {
                  CountryName="NE"

                },
                new CountryModel
                {
                    CountryName="SL"
                },
                 new CountryModel
                 {
                   CountryName="DEO2"
                 },
                new CountryModel
                {
                   CountryName="DEO3"
                },
            };
        }

        private void SetDomainList()
        {
            _domainModel.Clear();
            DomainListItem = new ObservableCollection<CategoryModel>
            {
                new CategoryModel
                {
                  DomainName="VIP",
                  IDtypeName="Passport",
                  CategoryName="Business visitor"

                },
                new CategoryModel
                {
                    DomainName="Exhibiter",
                    IDtypeName="Govt. ID",
                    CategoryName="General business"

                },
                 new CategoryModel
                 {
                   DomainName="Contractor",
                   IDtypeName="PAN Card"
                 },
                new CategoryModel
                {
                   DomainName="Service Provider",
                   IDtypeName="Adhar Card"
                },
                 new CategoryModel
                {
                  DomainName="Media"

                },
                new CategoryModel
                {
                    DomainName="Duty Pass"
                },
                
            };
        }

        /// <summary>
        /// Command
        /// </summary>
        /// <param name="obj"></param>
        private async void Back_Tap(object obj)
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());
            // await _navigationService.GoBackAsync();
            // await _navigationService.GoBackAsync();
        }

        public DelegateCommand CategorySelectioncommand => new DelegateCommand(() =>
        {
            if (count == 0)
            {
                //StackVisible = false;
                Pickervisible = true;
                count = 1;
            }
            else
            {
                Pickervisible = false;
                //   StackVisible = true;
                count = 0;
            }

        });
        public DelegateCommand CategoryBookSelectioncommand => new DelegateCommand(() =>
        {
            if (count == 0)
            {
                //StackVisible = false;
                Categoryvisible = true;
                count = 1;
            }
            else
            {
                Categoryvisible = false;
                //   StackVisible = true;
                count = 0;
            }

        });
       
        public DelegateCommand CountrySelectioncommand => new DelegateCommand(() =>
        {
            if (count == 0)
            {
                //StackVisible = false;
                Countryvisible = true;
                count = 1;
            }
            else
            {
                Countryvisible = false;
                //   StackVisible = true;
                count = 0;
            }

        });
        public DelegateCommand BookCountrySelectioncommand => new DelegateCommand(() =>
        {
            if (count == 0)
            {
                //StackVisible = false;
                Countrybookvisible = true;
                count = 1;
            }
            else
            {
                Countrybookvisible = false;
                //   StackVisible = true;
                count = 0;
            }

        });

        public DelegateCommand IDTypeSelectioncommand => new DelegateCommand(() =>
        {
            
            if (count == 0)
            {
                IDTypevisible = true;
                count = 1;
            }
            else
            {
                IDTypevisible = false;
                count = 0;
            }
        });
        public DelegateCommand BookIDSelectioncommand => new DelegateCommand(() =>
        {
            if (count == 0)
            {
                IDbookvisible = true;
                count = 1;
            }
            else
            {
                IDbookvisible = false;
                count = 0;
            }
        });

        public DelegateCommand GenderSelectioncommand => new DelegateCommand(() =>
        {
            if (count == 0)
            {
                //StackVisible = false;
                Gendervisible = true;
                count = 1;
            }
            else
            {
                Gendervisible = false;
                //   StackVisible = true;
                count = 0;
            }
        }); 
        public DelegateCommand UploadCommand => new DelegateCommand(() =>
        {
            MessagingCenter.Send<DashBoardScreenViewModel>(this, "upload");

        });
       

       // public DelegateCommand SaveCommand => new DelegateCommand(() =>
        private void Save_Tap(object obj)
        {
            //try
            //{
            //    PrintMessage += " Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            //    await _blueToothService.Print(SelectedDevice, PrintMessage);
            //}
            //catch(Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //}


            if (SelectedDomain != null )
            {
                if (SelectedCountry != null)
                {
                    if (IsValidate(_Username, "Username"))
                    {

                        if(textCompany != null)
                        {
                            if(SelectedGender != null)
                            {
                                if(SelectedID != null)
                                {
                                    if(MobileNum != null)
                                    {
                                        if (IsValidate(_entryEmail, "EntryEmail"))
                                        {
                                            if (IsValidate(_Password, "Password"))
                                            {
                                                MessagingCenter.Send<DashBoardScreenViewModel>(this, "Message");

                                            }
                                            else
                                            {
                                                App.Current.MainPage.DisplayAlert("Alert", "Please Enter Valid Password", "OK");

                                            }

                                        }
                                        else
                                        {
                                            App.Current.MainPage.DisplayAlert("Alert", "Please Enter Valid Email", "OK");

                                        }

                                    }
                                    else
                                    {
                                        App.Current.MainPage.DisplayAlert("Alert", "Please Enter mobile number", "OK");

                                    }

                                }
                                else
                                {
                                    App.Current.MainPage.DisplayAlert("Alert", "Please Select IDType", "OK");

                                }

                            }
                            else
                            {
                                App.Current.MainPage.DisplayAlert("Alert", "Please Select Gender", "OK");

                            }

                        }
                        else
                        {
                            App.Current.MainPage.DisplayAlert("Alert", "Please Enter Company Name", "OK");

                        }
                    }
                    else
                    {

                        App.Current.MainPage.DisplayAlert("Alert", "Please Enter valid Name", "OK");

                    }


                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Alert", "Please Select Country Name", "OK");

                }

            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alert", "Please Select Category", "OK");
            }

        }


        //void BindDeviceList()
        //{
        //    var list = _blueToothService.GetDeviceList();
        //    DeviceList.Clear();
        //    foreach (var item in list)
        //        DeviceList.Add(item);
        //}
    }
}

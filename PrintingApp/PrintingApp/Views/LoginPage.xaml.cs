using PrintingApp.Interface;
using Xamarin.Forms;

namespace PrintingApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Emailid_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(emailid.Text.ToString()))
            {
                emailid.Focus();
             //   DependencyService.Get<IKeyboardHelper>().HideKeyboard();
                //EntryPasscode1.TextChanged += (s, f) => EntryPasscode1.Focus();

            }
            else
            {
                pass.Focus();
                //EntryPasscode1.TextChanged += (s, f) => EntryPasscode2.Focus();

            }
        }

        private void Pass_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(pass.Text.ToString()))
            {
                emailid.Focus();
                //EntryPasscode2.TextChanged += (s, f) => EntryPasscode1.Focus();

            }
            else
            {
                pass.Focus();
                //EntryPasscode2.TextChanged += (s, f) => EntryPasscode3.Focus();

            }
        }
    }
}

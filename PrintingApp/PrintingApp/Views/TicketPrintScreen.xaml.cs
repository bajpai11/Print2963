using Xamarin.Forms;

namespace PrintingApp.Views
{
    public partial class TicketPrintScreen : ContentPage
    {
        public TicketPrintScreen(string printmsg)
        {
            InitializeComponent();

            txtMessage.Text = printmsg;
        }
    }
}

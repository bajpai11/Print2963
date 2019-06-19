using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace PrintingApp.Views
{
    public partial class TicketPrintScreen : ContentPage
    {
        Stream fileStream;
        public TicketPrintScreen()
        {
            InitializeComponent();

          //  txtMessage.Text = message;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            fileStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("PrintingApp.Assets.GIS Succinctly.pdf");
            //Load the PDF
            pdfViewerControl.LoadDocument(fileStream);
        }
    }
}

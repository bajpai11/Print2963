using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Input;
using PrintingApp.Interface;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Barcode;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace PrintingApp.Views
{
    public partial class RegistrationPage : ContentPage
    {
      //  public ICommand ScanCommand { get; set; }
      //  public ICommand BackCommand { get; set; }
        public RegistrationPage(string name, string email, string mobile, string company, string IDType, ImageSource img)
        {
            // ScanCommand = new Command(Scan_Tap);
           
            InitializeComponent();

          //  BackCommand = new Command(Back_Tap);
            textemail.Text = email;
            textname.Text = name;
            textMobile.Text = mobile;
            textCompany.Text = company;
            imgImage.Source = img;
            textIDType.Text = IDType;
           
            //     imageName.Source = imgName;
            



            var Entryvalue = email;
           // BarcodeImageView.BarcodeValue = $"Email:-{textemail.Text}, Mobile No.:-{textCompany.Text}, Name:{textname.Text}, ID No.:- {textKey.Text}";
             QRcodeImageView.BarcodeValue = App.Current.Properties["Passcode"].ToString();
           // BarcodeImageView.BarcodeValue= $"{textemail.Text}, {textCompany.Text}, {textname.Text}, {textMobile.Text}, {textIDType.Text},{"a"}";
            QRcodeImageView.IsVisible = true;

           //  BarcodeImageView.BarcodeValue = $"{textMobile.Text},{textIDType.Text},{textCompany.Text}";
              BarcodeImageView.BarcodeValue = App.Current.Properties["Barcodee"].ToString();

            BarcodeImageView.IsVisible = true;
        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //   // App.Current.MainPage=new NavigationPage(new MainPage());
        //}

        private void PDF_Clicked(object sender, EventArgs e)
        {

            //Create the pdfdocument 
            PdfDocument doc = new PdfDocument();

            //Add the page
            PdfPage page = doc.Pages.Add();

            //Create a new PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            PdfQRBarcode barcode = new PdfQRBarcode();
            PdfCode128ABarcode BarcodeA = new PdfCode128ABarcode();

            //Add three columns.
            pdfGrid.Columns.Add(2);

            //Setting string format for all the columns of PdfGrid
            PdfStringFormat format = new PdfStringFormat();

            format.Alignment = PdfTextAlignment.Center;

            format.LineAlignment = PdfVerticalAlignment.Bottom;

            pdfGrid.Columns[0].Format = format;

            pdfGrid.Columns[1].Format = format;


            //Add header.
            pdfGrid.Headers.Add(1);


            PdfGridRow pdfGridHeader = pdfGrid.Headers[0];

            pdfGridHeader.Cells[0].Value = "Name";

            pdfGridHeader.Cells[1].Value = "Value";

            pdfGridHeader.Style.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Bold);


            //Add rows.
            PdfGridRow pdfGridRow1 = pdfGrid.Rows.Add();

            pdfGridRow1.Cells[0].Value = "Email";

            //Get the Name field from Xamarin form page
            pdfGridRow1.Cells[1].Value = textemail.Text;



            PdfGridRow pdfGridRow2 = pdfGrid.Rows.Add();

            pdfGridRow2.Cells[0].Value = "Name";

            //Get the Address field from Xamarin form page
            pdfGridRow2.Cells[1].Value = textname.Text;



            PdfGridRow pdfGridRow3 = pdfGrid.Rows.Add();

            pdfGridRow3.Cells[0].Value = "ID No.";

            //Get the Account number field from Xamarin form page
            pdfGridRow3.Cells[1].Value = textIDType.Text;

            PdfGridRow pdfGridRow4 = pdfGrid.Rows.Add();

            pdfGridRow4.Cells[0].Value = "Mobile Number";

            //Get the Account number field from Xamarin form page
            pdfGridRow4.Cells[1].Value = textMobile.Text;

            //Draw the PdfGrid.

            pdfGrid.Draw(page, PointF.Empty);


             barcode.Text = $"Email:-{textemail.Text}, Mobile No.:-{textCompany.Text}, Name:{textname.Text}, ID No.:- {textKey.Text}";
             BarcodeA.Text = "11123995650";
            //Printing barcode on to the Pdf. 

            barcode.Draw(page, new PointF(120, 120));
            BarcodeA.Draw(page, new PointF(100, 180));
            //Save and close the document.
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            doc.Close();
            DependencyService.Get<ISave>().SaveTextAsync("Ticket.pdf", "application/pdf", stream);
        }


        //public async void Generate_Barcode(object sender, EventArgs e)
        //{

        // };

        //}
    }
}

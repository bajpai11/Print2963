using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using PrintingApp.Interface;

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System;
using System.IO;
using Xamarin.Forms;
namespace PrintingApp.Views
{
    public partial class CreatePDF : ContentPage
    {
        public CreatePDF()
        {
            InitializeComponent();
            GeneratePDF.Clicked += GeneratePDF_Clicked;
            pay.Clicked += Pay_Clicked;
          //  PermissionS();
        }

        private void Pay_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IAppPaymentService>().PhonePay("1");
        }

        //async void PermissionS()
        //{
        //    var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
        //    if (status != PermissionStatus.Granted)
        //    {
        //        var result = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
        //        if (result.ContainsKey(Permission.Storage))
        //        {
        //            status = result[Permission.Storage];
        //        }
        //    }
        //}

        private void GeneratePDF_Clicked(object sender, EventArgs e)
        {

            //Create the pdfdocument 
            PdfDocument doc = new PdfDocument();

            //Add the page
            PdfPage page = doc.Pages.Add();

            //Create a new PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();

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

            pdfGridHeader.Cells[0].Value = "Field";

            pdfGridHeader.Cells[1].Value = "Data";

            pdfGridHeader.Style.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Bold);


            //Add rows.
            PdfGridRow pdfGridRow1 = pdfGrid.Rows.Add();

            pdfGridRow1.Cells[0].Value = "Name";

            //Get the Name field from Xamarin form page
            pdfGridRow1.Cells[1].Value = Name.Text;



            PdfGridRow pdfGridRow2 = pdfGrid.Rows.Add();

            pdfGridRow2.Cells[0].Value = "Address";

            //Get the Address field from Xamarin form page
            pdfGridRow2.Cells[1].Value = Address.Text;



            PdfGridRow pdfGridRow3 = pdfGrid.Rows.Add();

            pdfGridRow3.Cells[0].Value = "Account Number";

            //Get the Account number field from Xamarin form page
            pdfGridRow3.Cells[1].Value = Account.Text;



            //Draw the PdfGrid.

            pdfGrid.Draw(page, PointF.Empty);


            //Save and close the document.

            MemoryStream stream = new MemoryStream();

            doc.Save(stream);
            doc.Close();

            DependencyService.Get<ISave>().SaveTextAsync("Invoice.pdf", "application/pdf", stream);
        }


    }
}

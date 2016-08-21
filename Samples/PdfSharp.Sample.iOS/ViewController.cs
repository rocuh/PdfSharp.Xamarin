using Foundation;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.IO;
using UIKit;

namespace PdfSharp.Sample.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        
        partial void UIButton3_TouchUpInside(UIButton sender)
        {
            var document = new PdfDocument();

            var page = document.AddPage();

            var gfx = XGraphics.FromPdfPage(page);

            var font = new XFont("Helvetica", 20);
            var fontBold = new XFont("Helvetica", 20, XFontStyle.Bold);
            var fontItalic = new XFont("Helvetica", 20, XFontStyle.Italic);

            var image = XImage.FromFile("frogs.jpg");

            gfx.DrawImage(image, 10, 10, 100, 70);

            gfx.DrawString("Test of PdfSharp on iOS", font, new XSolidBrush(XColor.FromArgb(0, 0, 0)), 10, 130);

            gfx.DrawString("Test of PdfSharp on iOS in bold", fontBold, new XSolidBrush(XColor.FromArgb(0, 0, 0)), 10, 170);

            gfx.DrawString("Test of PdfSharp on iOS in italic", fontItalic, new XSolidBrush(XColor.FromArgb(0, 0, 0)), 10, 210);

            var fileName = Path.Combine(Path.GetTempPath(), "test.pdf");

            document.Save(fileName);

            pdfView.ScalesPageToFit = true;
            pdfView.LoadRequest(new NSUrlRequest(new NSUrl(fileName, false)));
        }
    }
}
 
using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;
using System.Reflection;

namespace PdfSharp.Sample.Droid
{
    [Activity(Label = "PdfSharp.Sample.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate 
            {
                var document = new PdfDocument();

                var page = document.AddPage();

                var gfx = XGraphics.FromPdfPage(page);

                var font = new XFont("sans-serif", 20);
                var fontBold = new XFont("sans-serif", 20, XFontStyle.Bold);
                var fontItalic = new XFont("sans-serif", 20, XFontStyle.Italic);

                var assembly = typeof(MainActivity).GetTypeInfo().Assembly;
                var imageName = assembly.GetName().Name + ".frogs.jpg";

                XImage image;

                using (var stream = assembly.GetManifestResourceStream(imageName))
                {
                    image = XImage.FromStream(stream);
                }

                gfx.DrawImage(image, 10, 10, 100, 70);

                gfx.DrawString("Test of PdfSharp on Android", font, new XSolidBrush(XColor.FromArgb(0, 0, 0)), 10, 130);

                gfx.DrawString("Test of PdfSharp on Android in bold", fontBold, new XSolidBrush(XColor.FromArgb(0, 0, 0)), 10, 170);

                gfx.DrawString("Test of PdfSharp on Android in italic", fontItalic, new XSolidBrush(XColor.FromArgb(0, 0, 0)), 10, 210);

                document.Save(Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "test.pdf"));
            };
        }
    }
}


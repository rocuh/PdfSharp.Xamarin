using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using Xamarin.Forms;

namespace PdfSharp.XamarinFormsSample
{
    public class App : Application
    {
        public App()
        {
            var customWebView = new CustomWebView() { VerticalOptions = LayoutOptions.FillAndExpand };

            var button = new Button { Text = "Generate PDF" };
            button.Clicked += (s, e) =>
            {
                var systemHelper = DependencyService.Get<ISystemHelper>();

                var document = new PdfDocument();

                var page = document.AddPage();

                var gfx = XGraphics.FromPdfPage(page);

                var fontName = systemHelper.GetDefaultSystemFont();

                var font = new XFont(fontName, 20);
                var fontBold = new XFont(fontName, 20, XFontStyle.Bold);
                var fontItalic = new XFont(fontName, 20, XFontStyle.Italic);

                var assembly = typeof(App).GetTypeInfo().Assembly;
                var imageName = assembly.GetName().Name + ".frogs.jpg";

                XImage image;

                using (var stream = assembly.GetManifestResourceStream(imageName))
                {
                    image = XImage.FromStream(stream);
                }

                gfx.DrawImage(image, 10, 10, 100, 70);

                gfx.DrawString("Test of PdfSharp on Xamarin Forms", font, new XSolidBrush(XColor.FromArgb(0, 0, 0)), 10, 130);

                gfx.DrawString("Test of PdfSharp on Xamarin Forms in bold", fontBold, new XSolidBrush(XColor.FromArgb(0, 0, 0)), 10, 170);

                gfx.DrawString("Test of PdfSharp on Xamarin Forms in italic", fontItalic, new XSolidBrush(XColor.FromArgb(0, 0, 0)), 10, 210);

                var fileName = Path.Combine(systemHelper.GetTemporaryDirectory(), "test.pdf");
                document.Save(fileName);

                // using a webview to draw pdf on android this uses pdf.js (https://mozilla.github.io/pdf.js/)
                customWebView.Path = fileName;
            };

            // The root page of your application
            MainPage = new NavigationPage(new ContentPage
            {
                Title = "PdfSharp Sample",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Children = {
                        button,
                        customWebView
                    }
                }
            });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

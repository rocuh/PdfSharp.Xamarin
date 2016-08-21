using PdfSharp.XamarinFormsSample.iOS;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(SystemHelper))]

namespace PdfSharp.XamarinFormsSample.iOS
{
    public class SystemHelper : ISystemHelper
    {
        public string GetDefaultSystemFont()
        {
            return "Helvetica";
        }

        public string GetTemporaryDirectory()
        {
            return System.IO.Path.GetTempPath();
        }
    }
}
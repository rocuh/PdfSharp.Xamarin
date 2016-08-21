using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PdfSharp.XamarinFormsSample;
using PdfSharp.XamarinFormsSample.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SystemHelper))]

namespace PdfSharp.XamarinFormsSample.Droid
{
    public class SystemHelper : ISystemHelper
    {
        public string GetDefaultSystemFont()
        {
            return "sans-serif";
        }

        public string GetTemporaryDirectory()
        {
            return System.IO.Path.GetTempPath();
        }
    }
}
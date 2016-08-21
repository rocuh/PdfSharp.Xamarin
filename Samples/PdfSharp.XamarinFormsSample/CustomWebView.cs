using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PdfSharp.XamarinFormsSample
{
    public class CustomWebView : WebView
    {
        public static readonly BindableProperty PathProperty = BindableProperty.Create(nameof(Path), typeof(string), typeof(CustomWebView), default(string));

        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }
    }
}

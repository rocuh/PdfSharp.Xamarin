using System.IO;
using System.Net;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using PdfSharp.XamarinFormsSample;
using PdfSharp.XamarinFormsSample.iOS;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace PdfSharp.XamarinFormsSample.iOS
{
    public class CustomWebViewRenderer : ViewRenderer<CustomWebView, UIWebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomWebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new UIWebView());
            }
            if (e.OldElement != null)
            {
                // Cleanup
            }
            if (e.NewElement != null)
            {
                var customWebView = Element as CustomWebView;
                UpdateContent();
                Control.ScalesPageToFit = true;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CustomWebView.PathProperty.PropertyName)
            {
                UpdateContent();
            }
        }

        private void UpdateContent()
        {
            var customWebView = Element as CustomWebView;

            if (customWebView != null && customWebView.Path != null)
            {
                Control.LoadRequest(new NSUrlRequest(new NSUrl(customWebView.Path, false)));
            }
        }
    }
}
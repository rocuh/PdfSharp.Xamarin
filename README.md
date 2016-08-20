# PdfSharp.Xamarin
**PdfSharp.Xamarin** is a basic port of PdfSharp for iOS and Android using Xamarin, it allows for creation and modification of PDF files.

Currently all images created via XGraphics are converted to jpegs with 70% quality.

This is currently not a PCL library, so it works best for shared projects if your using Xamarin.Forms.

## Supported Platforms

- Android
- iOS

## Example

```cs
	var document = new PdfDocument();
	var page = document.AddPage();
	var gfx = XGraphics.FromPdfPage(page); 
	var font = new XFont("Verdana", 20);
	gfx.DrawString("Test of PdfSharp on iOS", font, new XSolidBrush(XColor.FromArgb(0, 0, 0)), 10, 130);
	document.Save(Path.Combine(Path.GetTempPath(), "test.pdf"));
```

# PdfSharp.Xamarin
**PdfSharp.Xamarin** is a partial port of [PdfSharp](http://www.pdfsharp.net/) for iOS and Android using Xamarin, it allows for creation and modification of PDF files.

Currently all images created via XGraphics are converted to jpegs with 70% quality.

## Supported Platforms

- Xamarin Android
- Xamarin iOS
- Xamarin.Forms

## Example

```cs
	var document = new PdfDocument();
	var page = document.AddPage();
	var gfx = XGraphics.FromPdfPage(page); 
	var font = new XFont("Verdana", 20);
	gfx.DrawString("Test of PdfSharp on iOS", font, new XSolidBrush(XColor.FromArgb(0, 0, 0)), 10, 130);
	document.Save(Path.Combine(Path.GetTempPath(), "test.pdf"));
```

## License

Copyright (c) 2005-2007 empira Software GmbH, Cologne (Germany)  
Modified work Copyright (c) 2016 David Dunscombe

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
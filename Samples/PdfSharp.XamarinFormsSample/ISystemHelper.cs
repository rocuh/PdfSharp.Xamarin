using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfSharp.XamarinFormsSample
{
    public interface ISystemHelper
    {
        string GetTemporaryDirectory();
        string GetDefaultSystemFont();
    }
}

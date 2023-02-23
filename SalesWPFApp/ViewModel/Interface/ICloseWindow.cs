using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWPFApp.ViewModel.Interface
{
    interface ICloseWindow
    {
        Action Close { get; set; }
    }
}

using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pconsulta.Models
{
    [AddINotifyPropertyChangedInterface]
    public class changeOptions
    {
        public bool status { get; set; }
    }
}

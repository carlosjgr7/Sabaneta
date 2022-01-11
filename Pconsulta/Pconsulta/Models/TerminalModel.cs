using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pconsulta.Models
{
    [AddINotifyPropertyChangedInterface]
    public class ResponseTerminal
    {
        public bool ok { get; set; }
        public Term[] term { get; set; }
        public string msg { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class Term
    {
        public string aboTerminal { get; set; }
    }

}

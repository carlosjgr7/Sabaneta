using System;
using System.Collections.Generic;
using System.Text;

namespace Pconsulta.Models
{

    public class ResponseTerminal
    {
        public bool ok { get; set; }
        public Term[] term { get; set; }
        public string msg { get; set; }
    }

    public class Term
    {
        public string aboTerminal { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace Pconsulta.Models
{

    public class responseNewOption
    {
        public string message { get; set; }
        public Info info { get; set; }
    }

    public class Info
    {
        public string title { get; set; }
        public string descript { get; set; }
        public int election { get; set; }
        public int votes { get; set; }
        public int id { get; set; }
        public int creator { get; set; }
        public bool status { get; set; }
    }
    class ResponseNewOption
    {
    }
}

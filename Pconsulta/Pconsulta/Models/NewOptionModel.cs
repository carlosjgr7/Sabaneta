using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Pconsulta.Models
{
    public class NewOptionModel
    {
        public string title { get; set; }
        public string descript { get; set; }
        public int election { get; set; }

    }
}

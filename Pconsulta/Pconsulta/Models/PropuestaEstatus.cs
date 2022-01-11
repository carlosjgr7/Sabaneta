using Pconsulta.Models.Login;
using System;
using System.Collections.Generic;
using System.Text;
using Pconsulta.Models.Election;
using PropertyChanged;

namespace Pconsulta.Models
{

    [AddINotifyPropertyChangedInterface]
    public class PropuestaEstatus
    {
        public Election.Option propuesta { get; set; }
        public int electionId { get; set; }
        public int staus { get; set; }
        public string token { get; set; }
        public bool opcVotada { get; set; }

    }
}

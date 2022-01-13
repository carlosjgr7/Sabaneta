using Pconsulta.Models.Election;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pconsulta.Models.Login
{
    [AddINotifyPropertyChangedInterface]
    public class LoginResponse
    {
        public string message { get; set; }
        public string token { get; set; }
        public Info info { get; set; }
        public Option option { get; set; }
        public Election election { get; set; }
        public Vote vote { get; set; }

    }

    [AddINotifyPropertyChangedInterface]
    public class Info
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public Role[] roles { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class Role
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class Option
    {
        public string title { get; set; }
        public string descript { get; set; }
        public int votes { get; set; }
        public int id { get; set; }
        public int creator { get; set; }
        public bool status { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class Vote
    {
        public string title { get; set; }
        public string descript { get; set; }
        public int votes { get; set; }
        public int id { get; set; }
        public int creator { get; set; }
        public bool status { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class Election
    {
        public int id { get; set; }
        public string name { get; set; }
        public Status status { get; set; }
        public DateTime deleteAt { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }


}

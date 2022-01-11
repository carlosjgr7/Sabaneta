using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pconsulta.Models.Election
{
    [AddINotifyPropertyChangedInterface]
    public class ElectionList
    {
        public string message { get; set; }
        public Info info { get; set; }
    }
    [AddINotifyPropertyChangedInterface]
    public class Info
    {
        public int id { get; set; }
        public string name { get; set; }
        public Status status { get; set; }
        public DateTime deleteAt { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public Option[] Options { get; set; }
    }
    [AddINotifyPropertyChangedInterface]
    public class Status
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
        public object[] Imgs { get; set; }
    }


}

﻿namespace Pconsulta.Models
{
    public class LoginResponseModel
    {
        public bool ok { get; set; }
        public string email { get; set; }
        public string identificacion { get; set; }
        public string nombre { get; set; }
        public string token { get; set; }
    }
}
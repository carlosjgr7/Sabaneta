using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pconsulta.Interfaces
{
    [Headers("Content-Type: application/json")]
    public interface IForgotPass
    {
        [Post("/auth/newPassEmail")]
        Task<string> ForgotPass([Body] Dictionary<string,string> email);
    }

    

}

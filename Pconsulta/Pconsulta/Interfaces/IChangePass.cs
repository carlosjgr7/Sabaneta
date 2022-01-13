using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pconsulta.Interfaces
{
    [Headers("Content-Type: application/json")]
    public interface IChangePass
    {
        [Post("/auth/users/newPass")]
        Task NewPass([Body] Dictionary<string, string> password, [Header("authorization")] string token);

    }
}

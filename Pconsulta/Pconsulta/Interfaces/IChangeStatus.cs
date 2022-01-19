using Pconsulta.Models;
using Pconsulta.Models.Election;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pconsulta.Interfaces
{
    [Headers("Content-Type: application/json")]
    interface IChangeStatus
    {
        [Put("/options/{id}")]
        Task PutElectionChange(string id, [Body] Dictionary<string,bool> status, [Header("authorization")] string token);
    }
}

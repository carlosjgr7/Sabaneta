using Pconsulta.Models;
using Pconsulta.Models.Election;
using Pconsulta.Models.Login;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pconsulta.Interfaces
{
    [Headers ("Content-Type: application/json")]
    public interface IOptionServices
    {
      
        [Get("/elections/{id}")]
        Task<ElectionList> GetElection(string id, [Header("authorization")] string token);
    }
}

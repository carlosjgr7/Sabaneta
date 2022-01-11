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
    public interface IVoteOptions
    {
        [Put("/elections/{election}/{option}")]
        Task PutVotation(string election, string option,[Body] msj msj, [Header("authorization")] string token);


    }
}

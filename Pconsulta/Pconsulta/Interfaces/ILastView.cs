using Pconsulta.Models.Election;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pconsulta.Interfaces
{
    [Headers("Content-Type: application/json")]
    public interface ILastView
    {
        [Get("/elections/ultimate")]
        Task<ElectionList> GetLastElection([Header("authorization")] string token);
    }
}

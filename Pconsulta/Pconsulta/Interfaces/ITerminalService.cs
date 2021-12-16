using Pconsulta.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pconsulta.Interfaces
{
    public interface ITerminalService
    {
        [Get("/puntoConsulta/{cedula}")]
        [Headers( "Content-Type: application/json")]
        Task<List<ResponseTerminal>> GetTermAsync(string cedula);
    }
}

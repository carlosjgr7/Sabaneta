using Pconsulta.Models;
using Pconsulta.Models.Election;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pconsulta.Interfaces
{
    [Headers("Content-Type: application/json")]
    public interface INewOption
    {
        [Post("/options")]
        Task<responseNewOption> PostNewOption([Body] NewOptionModel newOptionModel , [Header("authorization")] string token);
    }
}

using Pconsulta.Models;
using Refit;
using System.Threading.Tasks;

namespace Pconsulta.Interfaces
{
    public interface ILoginService
    {
        [Post("/auth/consulta")]
        [Headers("Content-Type: application/json")]
        Task<LoginResponseModel> PostLoginAsync([Body] LoginCredentialModel loginCredential);

        
    }
}
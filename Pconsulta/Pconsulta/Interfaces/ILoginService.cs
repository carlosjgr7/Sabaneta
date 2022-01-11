using Pconsulta.Models.Login;
using Refit;
using System.Threading.Tasks;

namespace Pconsulta.Interfaces
{
    public interface ILoginService
    {
        [Post("/auth/login")]
        [Headers("Content-Type: application/json")]
        Task<LoginResponse> PostLoginAsync([Body] LoginCredentialModel loginCredential);

        
    }
}
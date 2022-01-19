using Pconsulta.Models.Login;
using Refit;
using System.Threading.Tasks;

namespace Pconsulta.Interfaces
{
    [Headers("Content-Type: application/json")]
    public interface ILoginService
    {
        [Post("/auth/login")]
        Task<LoginResponse> PostLoginAsync([Body] LoginCredentialModel loginCredential);

        
    }
}
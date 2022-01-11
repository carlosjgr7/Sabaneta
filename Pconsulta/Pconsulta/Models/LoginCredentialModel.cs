using PropertyChanged;

namespace Pconsulta.Models.Login
{
    [AddINotifyPropertyChangedInterface]
    public class LoginCredentialModel
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}

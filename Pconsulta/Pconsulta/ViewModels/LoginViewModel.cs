
using FreshMvvm;
using Pconsulta.Interfaces;
using Pconsulta.Models.Login;
using Pconsulta.Utilities;
using Pconsulta.ViewModels;
using PropertyChanged;
using Refit;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Pconsulta.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : FreshBasePageModel
    {

        public string loginBtn { get; set; } = "Iniciar Sesión";
        public bool Loading { get; set; }

        public string User { get; set; } = Preferences.Get("emailUser","");
        public string Pass { get; set; } = Preferences.Get("passUser", "");
        

        public Command toMenuPageCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<forgotPass>();


            /*  if (SwitchMe)
              {
                  Preferences.Set("emailUser", User);
                  Preferences.Set("passUser", Pass);
              }
                  var loginApi = RestService.For<ILoginService>(StaticValues.baseUrl);


                  LoginCredentialModel loginCredential = new LoginCredentialModel()
                  {
                      email = User,
                      password = Pass
                  };

                  if (!String.IsNullOrEmpty(loginCredential.email) && !String.IsNullOrEmpty(loginCredential.password))
                  {
                      try
                      {
                      Loading = true;

                          var result = await loginApi.PostLoginAsync(loginCredential);

                          await CoreMethods.PushPageModel<PrincipalMenuViewModel>(result);
                      Loading = false;

                      }
                      catch(Exception e)
                      {
                          Console.WriteLine("mensaje de error: "+e.Message.ToString());
                          Loading = false;

                      await Application.Current.MainPage.DisplayAlert("Alerta", "Usuario o contraseña incorrectas", "ok");
                      }

                  }
                  else
                  {
                      Loading = false;
                      await Application.Current.MainPage.DisplayAlert("Alerta", "El correo y la contraseña no pueden ser vacios", "ok");
                  }*/
        });

        public Command ForgotPasswordCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<forgotPass>();
        });


        public bool SwitchMe
        {
            get => Preferences.Get(nameof(SwitchMe),false);
            set
            {
                Preferences.Set(nameof(SwitchMe), value);
                RaisePropertyChanged(nameof(SwitchMe));
            }
        }

    }
}
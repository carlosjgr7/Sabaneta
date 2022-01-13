using FreshMvvm;
using Pconsulta.Interfaces;
using Pconsulta.Models;
using Pconsulta.Models.Login;
using Pconsulta.PageModels;
using Pconsulta.Utilities;
using PropertyChanged;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Pconsulta.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class forgotPass:FreshBasePageModel
    {
        public string email { get; set; }
        public bool loading { get; set; }

       

        public Command toLoginPage => new Command(async () =>
        {
            loading = true;
            try
            {
                Dictionary<string, string> _email = new Dictionary<string, string>()
              {
                  { "email",email }
              };
                var loginApi = RestService.For<IForgotPass>(StaticValues.baseUrl);
               var result =  await loginApi.ForgotPass(_email);
                await Application.Current.MainPage.DisplayAlert("Envio Exitoso", "Por favor vaya a su correo y siga las instrucciones", "ok");
                await CoreMethods.PushPageModel<LoginViewModel>();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                await Application.Current.MainPage.DisplayAlert("No Enviado", "El correo proporcionado no esta registrado, por favor reviselo", "ok");

            }

            loading = false;
        });


      

    }
}

using FreshMvvm;
using Pconsulta.PageModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Pconsulta.ViewModels
{
    public class forgotPass:FreshBasePageModel
    {
        private string _email { get; set; }
        public bool _loading { get; set; }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;

            }
        }

        public Command toLoginPage => new Command(async () =>
        {
            Loading = true;
            //peticion para envio de correo
            //crear un if con la peticion correspondiente
            //satisfactorio
            if (false)
            {
                await Application.Current.MainPage.DisplayAlert("Envio Exitoso", "Por favor vaya a su correo y siga las instrucciones", "ok");
                await CoreMethods.PushPageModel<LoginViewModel>();
            }

            //no satisfactorio
            else
            {
                await Application.Current.MainPage.DisplayAlert("No Enviado", "El correo proporcionado no esta registrado,por favor reviselo", "ok");

            }
            Loading = false;
        });


        public bool Loading
        {
            get => _loading;
            set
            {
                _loading = value;
                RaisePropertyChanged(nameof(Loading));
            }
        }
    

    }
}

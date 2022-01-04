using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Pconsulta.ViewModels
{
    class ChangePassView : FreshBasePageModel
    {
        public bool _loading { get; set; }
        public string _pass { get; set; }
        public string _confirmPass { get; set; }

        public string Pass
        {
            get => _pass;
            set
            {
                _pass = value;

            }
        }
        
        public string ConfirmPass
        {
            get => _confirmPass;
            set
            {
                _confirmPass = value;

            }
        }
        public bool Loading
        {
            get => _loading;
            set
            {
                _loading = value;
                RaisePropertyChanged(nameof(Loading));
            }
        }



        public Command ChangePass => new Command(async () =>
        {
            Loading = true;
            //peticion para envio de correo
            //crear un if con la peticion correspondiente
            //satisfactorio
            if (Pass == ConfirmPass)
            {
                Loading = false;
                await Application.Current.MainPage.DisplayAlert("Exitoso", "Su contraseña ha sido cambiada exitosamente", "ok");
                await CoreMethods.PopPageModel(false);

            }

            //no satisfactorio
            else
            {
                Loading = false;
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor verifique que las contraseñas conincidan", "ok");
            }
            Loading = false;
        });
    }
}

using FreshMvvm;
using Pconsulta.Interfaces;
using Pconsulta.Utilities;
using PropertyChanged;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Pconsulta.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class ChangePassView : FreshBasePageModel
    {
        public bool Loading { get; set; }
        public string Pass { get; set; }
        public string ConfirmPass { get; set; }
        public string token { get; set; }



        public override void Init(object initData)
        {
            token = initData as string;
        }


        public Command ChangePass => new Command(async () =>
        {
            Loading = true;
            
            if (Pass == ConfirmPass)
            {
                try
                {
                    Dictionary<string, string> change = new Dictionary<string, string>()
                    {
                        { "password", Pass}
                    };

                    
                    var loginApi = RestService.For<IChangePass>(StaticValues.baseUrl);
                    await loginApi.NewPass(change,token);

                   var resp = await Application.Current.MainPage.DisplayAlert("Exitoso", "Su contraseña ha sido cambiada exitosamente.¿Desea recordar esta contraeña en el proximo inicio de Sesión?", "si","no");
                    if (resp)
                    {
                        Preferences.Set("passUser", Pass);

                    }
                    await CoreMethods.PopPageModel(false);

                    Loading = false;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    await Application.Current.MainPage.DisplayAlert("Error", "La contraseña tiene que tener entre 8 y 12 caracteres","ok");

                }
               

            }

            else
            {
                Loading = false;
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor verifique que las contraseñas conincidan", "ok");
            }
            Loading = false;
        });
    }
}

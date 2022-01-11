﻿
using FreshMvvm;
using Pconsulta.Interfaces;
using Pconsulta.Models.Login;
using Pconsulta.Utilities;
using Pconsulta.ViewModels;
using Refit;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Pconsulta.PageModels
{
    public class LoginViewModel : FreshBasePageModel
    {

        public string loginBtn { get; set; } = "Iniciar Sesión";
        private bool _isloading { get; set; } = false;

        //private string _user = "amendoza@tranred.com.ve";
        //private string _pass = "Tranred03.";
        private string _user { get; set; } = Preferences.Get("emailUser","");
        private string _pass { get; set; } = Preferences.Get("passUser", "");
        

        public Command toMenuPageCommand => new Command(async () =>
        {

            if (SwitchMe)
            {
                Preferences.Set("emailUser", _user);
                Preferences.Set("passUser", _pass);
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
                }
        });

        public Command ForgotPasswordCommand => new Command(async () =>
        {
            await CoreMethods.PushPageModel<forgotPass>();
        });



        public string User
        {
            get => _user;
            set
            {
                _user = value;
                RaisePropertyChanged(nameof(User));

            }
        }

        public string Pass 
        { 
            get => _pass;
            set
            {
                _pass = value;
                RaisePropertyChanged(nameof(Pass));
            }
        }

        public bool Loading
        {
            get => _isloading;
            set
            {
                _isloading = value;
                RaisePropertyChanged(nameof(Loading));
            }
        } 
        
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
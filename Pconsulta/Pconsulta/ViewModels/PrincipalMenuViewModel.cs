using FreshMvvm;
using Pconsulta.Interfaces;
using Pconsulta.Models;
using Pconsulta.PageModels;
using Refit;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Pconsulta.ViewModels
{
    public class PrincipalMenuViewModel : FreshBasePageModel
    {
        public LoginResponseModel PersonData { get; set; }
        public List<string> terminales { get; set; }


        public override void Init(object initData)
        {
            PersonData = initData as LoginResponseModel;
           // GetTerm();
        }

        private  async void GetTerm()
        {
            var loginApi = RestService.For<ITerminalService>("http://192.168.253.29:443/api");
            var result = await loginApi.GetTermAsync(PersonData.identificacion);

        }

        public List<string> Terminales
        {
            get => terminales;
            set
            {
                terminales = value;
                RaisePropertyChanged(nameof(Terminales));

            }
        }


        #region "Toolbar"
        private string _toolbarName { get; } = "Cerrar Sesión";
        public string ToolbarName
        {
            get => _toolbarName;
        }
        public Command Logout => new Command(async () =>
        {
            Time = DateTime.Now.ToString();
            await CoreMethods.PushPageModel<LoginViewModel>();
        });




        #endregion

        #region "Movimientos_Tab"

            
        const string _time = "myTime";

        public string Time
        {
            get => Preferences.Get(_time, DateTime.Now.ToString());
            set
            {
                Preferences.Set(_time, value);
                RaisePropertyChanged(nameof(Time));
            }
        }
       
        #endregion
        #region "CierreLote_Tab"



        #endregion
        #region "Services_Tab"



        #endregion

    }

}

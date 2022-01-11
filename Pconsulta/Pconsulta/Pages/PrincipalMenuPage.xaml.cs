using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pconsulta.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalMenuPage : ContentPage
    {
        public PrincipalMenuPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this,false);


        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var exit = await this.DisplayAlert("Cerrar sesión", "¿Esta seguro que desea salir de la aplicación?", "Sí", "No");

                if (exit)
                {
                    await this.Navigation.PopAsync();
                }
                   
            });
            return true;
          
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            this.DisplayAlert("Nueva Propuesta", "Servicio desactivado por carga a tiendas", "ok");
        }
    }
}
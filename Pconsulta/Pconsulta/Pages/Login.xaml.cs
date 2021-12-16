using Pconsulta.PageModels;
using Xamarin.Forms;

namespace Pconsulta.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            BindingContext = new LoginViewModel( );
        }

        protected override bool OnBackButtonPressed()
        {
            System.Environment.Exit(0);
            return false;
        }
    }
}
using FreshMvvm;
using Pconsulta.Interfaces;
using Pconsulta.PageModels;
using Refit;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pconsulta
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = FreshMvvm.FreshPageModelResolver.ResolvePageModel<LoginViewModel>();
            var navigationPage = new FreshMvvm.FreshNavigationContainer(page);

            MainPage = navigationPage;

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

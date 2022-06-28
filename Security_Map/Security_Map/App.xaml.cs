using System;
using Security_Map.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Security_Map
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

             MainPage = new NavigationPage(new Views.Usuarios.LoginView());
            //MainPage = new NavigationPage(new Views.Perfis.Perfil());
            //MainPage = new Page2();



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

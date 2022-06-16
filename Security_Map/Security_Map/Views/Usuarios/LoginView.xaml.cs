using FFImageLoading.Svg.Forms;
using Security_Map.ViewModels.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Security_Map.Views.Usuarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        UsuarioViewModel usuarioViewModel;

        public LoginView()
        {
            InitializeComponent();

            usuarioViewModel = new UsuarioViewModel();
            BindingContext = usuarioViewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new  CadastroUserView());
        }
    }
}
using Security_Map.Models;
using Security_Map.Services.Usuarios;
using Security_Map.ViewModels.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Security_Map.Views.Perfis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {
        
        public Perfil()
        {

            InitializeComponent();

            nomeLogin.Text = "Usuário: " + Application.Current.Properties["UsuarioUsername"].ToString();
            emailLogin.Text = "E-mail: " + Application.Current.Properties["UsuarioToken"].ToString();
            


        }
    }
}
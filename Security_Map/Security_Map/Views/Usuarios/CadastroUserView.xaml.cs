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
    public partial class CadastroUserView : ContentPage
    {
        private CadastroUsuarioViewModel cadViewModel;
        public CadastroUserView()
        {
            InitializeComponent();

            cadViewModel= new CadastroUsuarioViewModel();
            BindingContext = cadViewModel;
            Title = "Novo Usuario";
        }
    }
}
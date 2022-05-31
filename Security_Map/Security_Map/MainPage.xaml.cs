using Security_Map.ViewModels.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Security_Map
{
    public partial class MainPage : ContentPage
    {
        LocalizacaoViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();

            viewModel = new LocalizacaoViewModel();
            BindingContext = viewModel;

            LocalizacaoViewModel.MeuMapa = map;
            viewModel.InicializarMapa();
            viewModel.LocalizarEscola();
            viewModel.ExibirUsuariosNoMapa();
        }
    }
}

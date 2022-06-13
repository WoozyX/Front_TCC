using Security_Map.ViewModels.Usuarios;
using Security_Map.Views.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Security_Map
{
    public partial class MainPage : ContentPage
    {
        LocalizacaoViewModel viewModel;
        public static Map MeuMapa;  //Map _MeuMapa;
        public MainPage()
        {
            MeuMapa = new Map();

            InitializeComponent();
            //_MeuMapa = MeuMapa;
            viewModel = new LocalizacaoViewModel();
            BindingContext = viewModel;

            LocalizacaoViewModel.MeuMapa = map;
            viewModel.InicializarMapa();
            viewModel.LocalizarEscola();
            viewModel.ExibirUsuariosNoMapa();
        }

        private void Marcar_Localizacao(object sender, MapClickedEventArgs e)
        {
            viewModel.Marcar_Localizacao(e, btnOcorrencia);
            
            //TODO: Método na viewModel
            //viewModel.
            

        }

        private void AbrirTelaOcorrencia(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RegistroOcorrencia();
        }
    }
}

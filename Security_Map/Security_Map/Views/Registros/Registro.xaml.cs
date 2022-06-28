using Security_Map.Models;
using Security_Map.Services.Usuarios;
using Security_Map.ViewModels.Registros;
using Security_Map.ViewModels.Usuarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Security_Map.Views.Registros
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    
    public partial class Registro : ContentPage
    {
        private ListagemRegistroViewModel viewModel;
        private LocalizacaoViewModel localizacaoViewModel;
        public Registro()
        {
            InitializeComponent();
            viewModel = new ListagemRegistroViewModel();
            BindingContext = viewModel;
        }
        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");

            }
        }
    }
}
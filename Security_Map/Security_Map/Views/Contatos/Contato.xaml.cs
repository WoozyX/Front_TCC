using Plugin.Messaging;
using Security_Map.ViewModels.Contatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Security_Map.Views.Contatos
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contato : ContentPage
    {
        private ListagemContatoViewModel viewModel;
        public Contato()
        {
            InitializeComponent();
            viewModel = new ListagemContatoViewModel();
            BindingContext = viewModel;
            
            
        }

        
    }
}
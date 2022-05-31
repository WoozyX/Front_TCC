using Security_Map.Models;
using Security_Map.Services.Contatos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Security_Map.ViewModels.Contatos
{
    public class ListagemContatoViewModel : BaseViewModel
    {
        private ContatoService cService;

        public ObservableCollection<Contato> Contatos { get; set; }

        public ListagemContatoViewModel()
        {
            string token = Application.Current.Properties["UsuarioToken"].ToString();
            cService = new ContatoService(token);
            Contatos = new ObservableCollection<Contato>();
            _ = ObterContatos();
        }

        public async Task ObterContatos()
        {
            try
            {
                Contatos = await cService.GetContatosAsync();
                OnPropertyChanged(nameof(Contatos));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

       









    }
}

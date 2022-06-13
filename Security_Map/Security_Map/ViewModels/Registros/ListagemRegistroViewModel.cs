using Security_Map.Models;
using Security_Map.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Security_Map.ViewModels.Registros
{
    public class ListagemRegistroViewModel: BaseViewModel
    {
        private RegistroService rService;

        public ObservableCollection<Registro> Registros { get; set; }

        public ListagemRegistroViewModel()
        {
            string token = Application.Current.Properties["UsuarioToken"].ToString();
            rService = new RegistroService(token);
            Registros = new ObservableCollection<Registro>();
            _ = ObterRegistros();
        }   


        public async Task ObterRegistros()
        {
            try
            {
            
                Registros = await rService.GetRegistrosAsync();
                OnPropertyChanged(nameof(Registros));

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
                
            }
        }



            
    }
}

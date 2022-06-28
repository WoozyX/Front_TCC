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
        private Registro ocorrenciaSelecionada;

        public Registro OcorrenciaSelecionada
        {
            get { return ocorrenciaSelecionada; }
            set
            {
                if (value != null)
                {
                    ocorrenciaSelecionada = value;

                    Shell.Current
                        .GoToAsync($"MainPage?RuaRegistro={ocorrenciaSelecionada.RuaRegistro}");
                }
            }
        }


        public async Task ObterRegistros()
        {
            try
            {
            
                Registros = await rService.GetRegistrosAsync();

                List<Registro> listaRegistros = new List<Registro>(Registros);             


                foreach (Registro r in listaRegistros)
                {

                    if (!string.IsNullOrEmpty(r.Latitude) && !string.IsNullOrEmpty(r.Longitude))
                    {
                        double lat = double.Parse(r.Latitude);
                        double lon = double.Parse(r.Longitude);

                        Location posicaoPin = new Location(lat, lon);
                        var localizacaoAprox = await Geocoding.GetPlacemarksAsync(posicaoPin);
                        var localizacaoAproxInfo = localizacaoAprox?.FirstOrDefault();
                        r.RuaRegistro = localizacaoAproxInfo.Thoroughfare;
                    }
                }
                Registros = new ObservableCollection<Registro>(listaRegistros);
                OnPropertyChanged(nameof(Registros));

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
                
            }
        }



            
    }
}

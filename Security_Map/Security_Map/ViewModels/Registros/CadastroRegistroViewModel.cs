using Security_Map.Models;
using Security_Map.Services.Usuarios;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Security_Map.ViewModels.Registros
{

    public class CadastroRegistroViewModel : BaseViewModel
    {
        public static Map MeuMapa;
        private RegistroService rService;
        public ICommand SalvarCommand { get; set; }
        public CadastroRegistroViewModel()
        {
            string token = Application.Current.Properties["UsuarioToken"].ToString();
            rService = new RegistroService(token);
            MeuMapa = new Map();

            SalvarCommand = new Command(async () => await RegistrarOcorrencia());
        }

        private int id;
        private string longitude;
        private string latitude;
        private string mtRegistro;
        private string mtRegistrado;
        private string dsRegistro;
        private int tiposOcorrenciasId;

        public int Id 
        { 
            get => id;
            set 
            {
                id = value;
                OnPropertyChanged();
            }
            
        }
        public string Longitude
        {
            get => longitude;
            set
            {
                longitude = value;
                OnPropertyChanged();
            }

        }
        public string Latitude
        {
            get => latitude;
            set
            {
                latitude = value;
                OnPropertyChanged();
            }

        }

        public string MtRegistro
        {
            get => mtRegistro;
            set
            {
                mtRegistro = value;
                OnPropertyChanged();
            }

        }
        public string MtRegistrado
        {
            get => mtRegistrado;
            set
            {
                mtRegistrado = value;
                OnPropertyChanged();
            }

        }
        public string DsRegistro
        {
            get => dsRegistro;
            set
            {
                dsRegistro = value;
                OnPropertyChanged();
            }

        }
        public int TiposOcorrenciasId
        {
            get => tiposOcorrenciasId;
            set
            {
                tiposOcorrenciasId = value;
                OnPropertyChanged();
            }

        }





        public async Task RegistrarOcorrencia()
        {
            try
            {
                Registro model = new Registro();
                {
                    Id = this.Id;
                    Longitude = this.Longitude;
                    Latitude = this.Latitude;
                    MtRegistro = this.MtRegistro;
                    MtRegistrado = this.MtRegistrado;
                    dsRegistro = this.DsRegistro;
                    TiposOcorrenciasId = this.TiposOcorrenciasId;
                };
                if (model.Id == 0)
                    await rService.PostRegistroAsync(model);

                await Application.Current.MainPage.DisplayAlert("Sucesso!", "Ocorrência registrada!", "Ok");

                
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "Detalhes: " + ex.InnerException, "Ok");
            }
        }


    }
}
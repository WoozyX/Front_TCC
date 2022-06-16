using Security_Map.Models;
using Security_Map.Services.Usuarios;
using Security_Map.ViewModels.Usuarios;
using Security_Map.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Security_Map.ViewModels.Registros
{

    public class CadastroRegistroViewModel : BaseViewModel
    {
        public static Map MeuMapa;
        public LocalizacaoViewModel localizacaoViewModel;
        private RegistroService rService;
        public ICommand SalvarCommand { get; set; }
        public ICommand CancelarCommand { get; set; }

        public CadastroRegistroViewModel(string latitudePoint, string longitudePoint)
        {
            string token = Application.Current.Properties["UsuarioToken"].ToString();
            rService = new RegistroService(token);
            MeuMapa = new Map();
            localizacaoViewModel = new LocalizacaoViewModel();
            SalvarCommand = new Command(async () => await RegistrarOcorrencia());
            CancelarCommand = new Command(async =>  CancelarRegistro());
            longitude = longitudePoint;
            latitude = latitudePoint;
            mtRegistrado = DateTime.Now.ToString();
            _ = ObterOcorrencia();
        }
        /*Conexão foreign key tipos Ocorrencias*/
        private ObservableCollection<TipoOcorrencias> listaTiposOcorrencia;

        private ObservableCollection<TipoOcorrencias> ListatiposOcorrencias
        {
            get { return listaTiposOcorrencia; }
            set
            {
                if(value != null)
                {
                    listaTiposOcorrencia = value;
                    OnPropertyChanged();
                }
            }
        }



        public async Task ObterOcorrencia()
        {
            try
            {
                ListatiposOcorrencias = new ObservableCollection<TipoOcorrencias>();
                ListatiposOcorrencias.Add(new TipoOcorrencias() { Id = 1, dsTipoOcorrencia = "Furto" });
                ListatiposOcorrencias.Add(new TipoOcorrencias() { Id = 2, dsTipoOcorrencia = "Agressão" });
                ListatiposOcorrencias.Add(new TipoOcorrencias() { Id = 1, dsTipoOcorrencia = "Assédio" });
                ListatiposOcorrencias.Add(new TipoOcorrencias() { Id = 1, dsTipoOcorrencia = "Roubo" });
                OnPropertyChanged(nameof(ListatiposOcorrencias));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
                
            }
            

        }

        private TipoOcorrencias tipoOcorreciaSelecionado;

        public TipoOcorrencias TipoOcorreciaSelecionado 
        {
            get { return tipoOcorreciaSelecionado; }
            set
            {
                if(value != null)
                {
                    tipoOcorreciaSelecionado = value;
                    OnPropertyChanged();
                }
            }

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
                switch (TiposOcorrenciasId)
                {
                    case 0:
                        this.TiposOcorrenciasId = 1;
                        break;
                    case 1:
                        this.TiposOcorrenciasId = 2;
                        break;
                    case 2:
                        this.TiposOcorrenciasId = 3;
                        break;
                    case 3:
                        this.TiposOcorrenciasId = 4;
                        break;
                }

                Registro model = new Registro()
                {
                   
                    Longitude = this.Longitude,
                    Latitude = this.Latitude,
                    MtRegistro = this.MtRegistro,
                    MtRegistrado = this.MtRegistrado,
                    dsRegistro = this.DsRegistro,
                    TiposOcorrenciasId = this.TiposOcorrenciasId

            };
                
                await rService.PostRegistroAsync(model);

                await Application.Current.MainPage.DisplayAlert("Sucesso!", "Ocorrência registrada!", "Ok");


                Application.Current.MainPage = new FlyoutMenu();

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        private async void CancelarRegistro()
        {
            Application.Current.MainPage = new FlyoutMenu();
        }


    }
}
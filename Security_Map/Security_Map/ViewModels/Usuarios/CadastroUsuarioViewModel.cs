using Security_Map.Models;
using Security_Map.Services.Usuarios;
using Security_Map.Views.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Security_Map.ViewModels.Usuarios
{
    public class CadastroUsuarioViewModel:BaseViewModel
    {
        private UsuarioService uService;
        public ICommand SalvarCommand { get; set; }
        public ICommand CancelarCommand { get; set; }

        public CadastroUsuarioViewModel()
        {
                string token = Application.Current.Properties["UsuarioToken"].ToString();
                uService = new UsuarioService();

            SalvarCommand = new Command(async () => await SalvarUsuario());
            CancelarCommand = new Command(async  =>  CancelarCadastro());
        }

        private int id;
        private string username;
        private string passwordString;
        private string token;
        private string imei_Cliente;
        private string email_Cliente;
        private string sexo_Cliente;
        private string telefone_Cliente;
        private string nascimento_Cliente;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }
        public string PasswordString
        {
            get => passwordString;
            set
            {
                passwordString = value;
                OnPropertyChanged();
            }
        }
        public string Token
        {
            get => token;
            set
            {
                token = value;
                OnPropertyChanged();
            }
        }
        public string Imei_Cliente
        {
            get => imei_Cliente;
            set
            {
                imei_Cliente = value;
                OnPropertyChanged();
            }
        }
        public string Email_Cliente
        {
            get => email_Cliente;
            set
            {
                email_Cliente = value;
                OnPropertyChanged();
            }
        }
        public string Sexo_Cliente
        {
            get => sexo_Cliente;
            set
            {
                sexo_Cliente = value;
                OnPropertyChanged();
            }
        }
        public string Telefone_Cliente
        {
            get => telefone_Cliente;
            set
            {
                telefone_Cliente = value;
                OnPropertyChanged();
            }
        }
        public string Nascimento_Cliente
        {
            get => nascimento_Cliente;
            set
            {
                nascimento_Cliente = value;
                OnPropertyChanged();
            }
        }

        

        public async Task SalvarUsuario()
        {
            try
            {
                int sexoIndex = int.Parse(Sexo_Cliente);
                if(sexoIndex > 0)
                {
                    this.Sexo_Cliente = "Feminino";
                }
                else
                {
                    this.Sexo_Cliente = "Masculino";
                }
                Usuario model = new Usuario()
                {
                    Username = this.Username,
                    PasswordString = this.PasswordString,
                    Token = this.Token,
                    Imei_Cliente = this.Imei_Cliente,
                    Email_Cliente = this.Email_Cliente,
                    Sexo_Cliente = this.Sexo_Cliente,
                    Telefone_Cliente = this.Telefone_Cliente,
                    Nascimento_Cliente = this.Nascimento_Cliente,
                    Id = this.Id


                    /*private string token;
                    private string imei_Cliente;
                    private string email_Cliente;
                    private string sexo_Cliente;
                    private string telefone_Cliente;
                    private string nascimento_Cliente;*/

                };
                if(model.Id == 0)
                    await uService.PostRegistroUsuarioAsync(model);

                await Application.Current.MainPage.DisplayAlert("Mensagem", "Dados salvos com sucesso!", "Ok");

                

                
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");

                
            }
        }

        private async void CancelarCadastro()
        {
            Application.Current.MainPage = new LoginView();
        }















    }
}

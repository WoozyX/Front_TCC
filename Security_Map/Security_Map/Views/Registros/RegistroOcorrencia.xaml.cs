using Security_Map.ViewModels.Registros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Security_Map.Views.Registros
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroOcorrencia : ContentPage
    {
        private CadastroRegistroViewModel cadViewModel;
        public RegistroOcorrencia(string latitudePoint, string longitudePoint)
        {
            InitializeComponent();

            cadViewModel = new CadastroRegistroViewModel(latitudePoint, longitudePoint);
            BindingContext = cadViewModel;
            Title = "Nova Ocorrência";
            dtpMtOcorrencia.MaximumDate = DateTime.Now;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new FlyoutMenu();
        }
    }
}
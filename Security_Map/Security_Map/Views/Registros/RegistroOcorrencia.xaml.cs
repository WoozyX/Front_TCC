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
        public RegistroOcorrencia()
        {
            InitializeComponent();

            cadViewModel = new CadastroRegistroViewModel();
            BindingContext = cadViewModel;
            Title = "Nova Ocorrência";
        }

        
    }
}
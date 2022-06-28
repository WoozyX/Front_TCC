using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Security_Map
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<Application, string>(this, "GlobalKeyUp", (sender, evt) =>
            {

                Application.Current.MainPage.DisplayAlert("Key up event", evt, "Ok");
                if (evt == "VolumeUp")
                {
                    // txtname.Focus();
                }

            });
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<Application, string>(this, "GlobalKeyUp");
        }
    }
}
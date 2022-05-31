using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Security_Map.Models;
using Security_Map.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Security_Map.ViewModels.Usuarios
{
    public class LocalizacaoViewModel
    {
        public static Map MeuMapa;
        private RegistroService rService;
        public LocalizacaoViewModel()
        {

            MeuMapa = new Map();

            string token = Application.Current.Properties["UsuarioToken"].ToString();
            rService = new RegistroService(token);
        }


        public async void InicializarMapa()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationPermission>();

                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await Application.Current.MainPage.DisplayAlert("Atenção", "É necessário ativar localização" , "Ok");
                    }
                    status = await CrossPermissions.Current.RequestPermissionAsync<LocationPermission>();
                }
                if (status == PermissionStatus.Granted)
                {
                    MeuMapa.MyLocationEnabled = true;
                    MeuMapa.UiSettings.MyLocationButtonEnabled = true;
                }
                else if (status != PermissionStatus.Unknown)
                    throw new Exception("Localização negada");


                

                Pin pinCentro = new Pin()
                {
                    Type = PinType.SavedPin,
                    Label = "São Paulo",
                    Position = new Position(-23.5504685, -46.6306803),

                };
                MeuMapa.Pins.Add(pinCentro);
                MeuMapa.MoveToRegion(MapSpan.FromCenterAndRadius(pinCentro.Position, Distance.FromMeters(1000)));

            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public async void LocalizarEscola()
        {
            try
            {
                var status = await CrossPermissions.Current
                    .CheckPermissionStatusAsync<LocationPermission>();

                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await Application.Current.MainPage.DisplayAlert("Atenção", "É necessário ativar a localização", "OK");

                    }

                    status = await CrossPermissions.Current.RequestPermissionAsync<LocationPermission>();


                }
                if (status == PermissionStatus.Granted)
                {
                    /*Pin pinEtec = new Pin()
                    {
                        Type = PinType.Place,
                        Label = "Etec Horácio",
                        Address = "Rua alcântara, 113, Vila Guilherme",
                        Position = new Position(-23.5200241d, -46.596498d),
                        Tag = "IdEtec",
                    };
                    MeuMapa.Pins.Add(pinEtec);
                   */

                    /*var circle1 = new Circle();
                    circle1.StrokeWidth = 1f;
                    circle1.StrokeColor = Xamarin.Forms.Color.Transparent;
                    circle1.FillColor = Xamarin.Forms.Color.FromRgba(255, 0, 0, 0.6);
                    circle1.Center = new Position(-23.5200241d, -46.596498d);
                    circle1.Radius = Distance.FromMeters(200);*/

                    
                }
                else if (status != PermissionStatus.Unknown)
                    throw new Exception("Localização negada");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public async void ExibirUsuariosNoMapa()
        {
            try
            {
                ObservableCollection<Registro> ocRegistros = await rService.GetRegistrosAsync();

                List<Registro> listaRegistros = new List<Registro>(ocRegistros);

                //await Application.Current.MainPage.DisplayAlert("Longitude")
                

                foreach (Registro r in listaRegistros)
                {
                    
                    if(!string.IsNullOrEmpty(r.Latitude) && !string.IsNullOrEmpty(r.Longitude))
                    {
                        double  lat = double.Parse(r.Latitude);
                        double lon = double.Parse(r.Longitude);

                        var circle1 = new Circle();
                        circle1.StrokeWidth = 1f;
                        circle1.StrokeColor = Xamarin.Forms.Color.Transparent;
                        circle1.FillColor = Xamarin.Forms.Color.FromRgba(139, 0, 0, 0.4);
                        circle1.Center = new Position(lat, lon);
                        circle1.Radius = Distance.FromMeters(200);

                        /*Pin pinTeste = new Pin()
                        {
                            Type = PinType.Place,
                            Label = r.MtRegistro,
                            Position = new Position(lat, lon)
                        };

                        MeuMapa.Pins.Add(pinTeste);*/

                        MeuMapa.Circles.Add(circle1);

                    }


                }
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Atenção", ex.Message, "Ok");
            }
        }






    }

}


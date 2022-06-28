using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Security_Map.Models;
using Security_Map.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Map = Xamarin.Forms.GoogleMaps.Map;
using PermissionStatus = Plugin.Permissions.Abstractions.PermissionStatus;

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
                var location = await Geolocation.GetLastKnownLocationAsync();
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
                    Position position = new Position(location.Latitude, location.Longitude);
                    MeuMapa.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMeters(1000)));
                }
                else if (status != PermissionStatus.Unknown)
                    throw new Exception("Localização negada");


                

                

            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public async void LocalizarOcorrencia(double lat, double lon)
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
                    Position position = new Position(lat, lon);
                    MeuMapa.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMeters(1000)));
                }
                else if (status != PermissionStatus.Unknown)
                    throw new Exception("Localização negada");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
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

                        Location posicaoPin = new Location(lat, lon);
                        var localizacaoAprox = await Geocoding.GetPlacemarksAsync(posicaoPin);
                        var localizacaoAproxInfo = localizacaoAprox?.FirstOrDefault();
                        r.RuaRegistro = localizacaoAproxInfo.Thoroughfare;

                        Registro registro = new Registro()
                        {
                            RuaRegistro = r.RuaRegistro
                        };

                        var circle1 = new Circle();
                        circle1.StrokeWidth = 1f;
                        circle1.StrokeColor = Xamarin.Forms.Color.Transparent;
                        circle1.FillColor = Xamarin.Forms.Color.FromRgba(139, 0, 0, 0.4);
                        circle1.Center = new Position(lat, lon);
                        circle1.Radius = Distance.FromMeters(150);

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


        public async void Marcar_Localizacao(MapClickedEventArgs parametros, Button botao)
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
                    MeuMapa.Pins.Clear();
                    Location posicaoPin = new Location(parametros.Point.Latitude, parametros.Point.Longitude);
                    var localizacaoAprox = await Geocoding.GetPlacemarksAsync(posicaoPin);
                    var localizacaoAproxInfo = localizacaoAprox?.FirstOrDefault();

                    //localizacaoAproxInfo.Thoroughfare = rua
                    //localizacaoAproxInfo.Locality = cidade ou estado
                    //localizacaoAproxInfo.PostalCode = CEP
                    //localizacaoAproxInfo.CountryName = nome da cidade
                    //localizacaoAproxInfo.CountryCode = codigo da cidade ex: 
                    Pin pinOcorrencia = new Pin()
                    {
                        Type = PinType.Place,
                        Label = "Ocorrência",
                        Address = localizacaoAproxInfo.Thoroughfare,
                        Position = parametros.Point
                    };
                    MeuMapa.MoveToRegion(MapSpan.FromCenterAndRadius(pinOcorrencia.Position, Distance.FromMeters(100)));
                    MeuMapa.Pins.Add(pinOcorrencia);
                    botao.IsVisible = true;

                    Registro registro = new Registro()
                    {
                        RuaRegistro = localizacaoAproxInfo.Thoroughfare.ToString()
                    };
                }
                else if (status != PermissionStatus.Unknown)
                    throw new Exception("Localização negada");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }

}


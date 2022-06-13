﻿using Security_Map.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Security_Map.Services.Usuarios
{
    public class RegistroService : Request
    {
        private readonly Request _request;
        private const string ApiUrlBase = "http://SecMap.somee.com/tcc/Registro";


        private string _token;

        public RegistroService(string token)
        {
            _request = new Request();
            _token = token;
                    
        }

        

       
        public async Task<ObservableCollection<Registro>> GetRegistrosAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Registro> listaRegistros = await _request.GetAsync
                <ObservableCollection<Models.Registro>>(ApiUrlBase + urlComplementar, _token);
            return listaRegistros;
        }

        public async Task<Registro> PostRegistroAsync(Registro r)
        {
            return await _request.PostAsync(ApiUrlBase, r, _token);
        }



    }
}

using Security_Map.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security_Map.Services.Usuarios
{
    public class UsuarioService : Request
    {
        private readonly Request _request;
        private const string ApiUrlBase = "http://SecMap.somee.com/tcc/Cliente";

        public UsuarioService()
        {
            _request = new Request();
        }

        public async Task<Usuario> PostLoginUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Autenticar";
            u.Token = await _request.PostReturnStringAsync(ApiUrlBase + urlComplementar, u);
            return u;
        }

        

        


        /*public async Task<Usuario> PostRegistroUsuarioAsync(Usuario u)
        {
            return await _request.PostAsync(ApiUrlBase, u, _token);
        }*/

        public async Task<Usuario> PostRegistroUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Registrar";
            u.Token = await _request.PostReturnStringAsync(ApiUrlBase + urlComplementar, u);
            return u;
        }


    }
}

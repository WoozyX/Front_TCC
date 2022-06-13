using Security_Map.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security_Map.Services.Contatos
{
    public class ContatoService : Request
    {
        private readonly Request _request = null;
        private string _token;
        private const string ApiUrlBase = "http://SecMap.somee.com/tcc/Contato"; 

        public ContatoService(string token)
        {
            _request = new Request();
            _token = token;

        }

        /*public async Task<Contato> PostContatoAsync(Contato c)
        {
            return await _request.PostAsync(ApiUrlBase, c, _token);
        }*/
        public async Task<ObservableCollection<Contato>> GetContatosAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Contato> listaContatos = await _request.GetAsync
                <ObservableCollection<Models.Contato>>(ApiUrlBase + urlComplementar, _token); 
            return listaContatos;
        }

        /*public async Task<ObservableCollection<Contato>> GetContatoAsync(int contatoId)
        {
            ObservableCollection<Models.Contato> listaPersonagens = await _request.GetAsync
                <ObservableCollection<Models.Contato>>(ApiUrlBase, _token); var contatoFiltrado = listaPersonagens.Where(p => p.Id == contatoId);
            return new ObservableCollection<Contato>(contatoFiltrado);
        }
        public async Task<Contato> PutContatoAsync(Contato c)
        {
            var result = await _request.PutAsync(ApiUrlBase, c, _token);
            return result;
        }
        public async Task<Contato> DeleteContatoAsync(int contatoId)
        {
            string urlComplementar = string.Format("/{0}", contatoId);
            await _request.DeleteAsync(ApiUrlBase + urlComplementar, _token); return new Contato() { Id = contatoId };
        }*/
    }
}

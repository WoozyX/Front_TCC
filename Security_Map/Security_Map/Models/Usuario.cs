using System;
using System.Collections.Generic;
using System.Text;

namespace Security_Map.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Imei_Cliente { get; set; }
        public string Email_Cliente { get; set; }
        public string Username { get; set; }
        public string PasswordString { get; set; }
        public string Sexo_Cliente { get; set; }
        public string Telefone_Cliente { get; set; }
        public string Nascimento_Cliente { get; set; }
        public string Perfil { get; set; }
        public string Token { get; set; }
        public byte[] Foto { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Security_Map.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome_Contato { get; set; }
        public string Tel_contato { get; set; }
        public int ClienteId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProvaLab2.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public string Nome { get; set; }        
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Pessoa> Pessoas { get; set; }
        //public string Apelido { get; set; }
        public string Email2 { get; set; }

    }
}
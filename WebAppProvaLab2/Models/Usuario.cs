using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProvaLab2.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Senha { get; set; }
        public bool Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
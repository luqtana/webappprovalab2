using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProvaLab2.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Email { get; set; }
        public string Matricula { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int ProfissaoId { get; set; }
        public virtual Profissao Profissao { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }


    }
}
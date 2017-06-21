using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProvaLab2.Models
{
    public class Profissao
    {
        public int ProfissaoId { get; set; }
        public string Descricao { get; set; }
        public string CBO { get; set; }
        public virtual ICollection<Pessoa> Pessoas { get; set; }

    }
}
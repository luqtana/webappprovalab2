using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAppProvaLab2.Models;

namespace WebAppProvaLab2.Contexto
{
    public class InicializacaoCustomizadoEF : DropCreateDatabaseIfModelChanges<ContextoEF>
    {

        public InicializacaoCustomizadoEF()
        {


        }

        private void PopularDados(ContextoEF context)
        {
            var profissoes = new List<Profissao>()
            {
                new Profissao {
                    CBO = "5252",
                    Descricao = "Analista de TI",
                },

                new Profissao {
                    CBO = "1010",
                    Descricao = "Engenheiro de Software",
                },
            };
            context.Profissoes.AddRange(profissoes);

            var contatos = new List<Contato>()
            {
                new Contato {
                   Nome = "Bill Gates",
                   Email = "contato@contato.com.br",
                   Telefone1 = "65655",
                   Telefone2 = "656211215",
                   Email2 = "teste@teste.com.br"
                },

                new Contato {
                   Nome = "Allan Turing",
                   Email = "contato2@contato2.com.br",
                   Telefone1 = "111111111",
                   Telefone2 = "22222222",
                   Email2 = "teste2@teste.com.br"
                },
            };
            context.Contatos.AddRange(contatos);

            var pessoas = new List<Pessoa>()
            {
                    new Pessoa()
                    {
                      Nome = "Marcio",
                      Sobrenome = "Queiroz",
                      CPF = "222222222222",
                      //DataCadastro = new DateTime(2017, 05, 23),
                       DataCadastro = DateTime.Now,
                       DataNascimento = new DateTime(2000, 05, 23),
                       Email = "marcio@teste.com.br",
                       Profissao = profissoes[0],
                       Contatos = new List<Contato>
                       {
                           contatos[0],
                           contatos[1]
                       },
                       Matricula = "1212",

                    },


            };
            context.Pessoas.AddRange(pessoas);
        }


        protected override void Seed(WebAppProvaLab2.Contexto.ContextoEF context)
        {
            if (context.Pessoas.Count() == 0)
            {
                try
                {
                    PopularDados(context);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // TODO: fazer log de erro
                    ex.ToString();
                }
            }
        }
    }
}
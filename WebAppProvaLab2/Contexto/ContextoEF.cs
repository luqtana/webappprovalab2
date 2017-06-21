using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebAppProvaLab2.Models;

namespace WebAppProvaLab2.Contexto
{
    public class ContextoEF : DbContext
    {
        public ContextoEF():base("name=strConexao")
        {
            //Altera o banco para última versão(mais recente)sem o comando update-database.
            //Database.SetInitializer(
            //  new MigrateDatabaseToLatestVersion<ContextoEF, Migrations.Configuration>("strConexao")
            //);

            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContextoEF>());

            //Estratégia Customizada para o Entity Framework
            Database.SetInitializer(new InicializacaoCustomizadoEF());


        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Profissao> Profissoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions
                .Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Conventions
                .Remove<ManyToManyCascadeDeleteConvention>();

            //Mapeias todas as classes para o tipo stored procedures
            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());

            //Configuraçãoes Fluent API
            //Associacão um para um entre Pessoa e Usuario

            modelBuilder.Entity<Pessoa>()
                .HasOptional(u => u.Usuario)
                .WithRequired(p => p.Pessoa)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.DataCadastro)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.DataNascimento)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Usuario>()
                 .Property(p => p.DataCadastro)
                 .HasColumnType("datetime2");

            modelBuilder.Entity<Usuario>()
              .ToTable("TbUsuario");
            

        }
    }
}
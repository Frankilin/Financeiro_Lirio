using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using FinanceiroLirio.Entidades;
using FinanceiroListio.Infra.Mappings;

namespace FinanceiroListio.Infra.DataSource
{
    public class Conexao : DbContext
    {
        public Conexao()
            : base(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
            //Resolve o problema de formatação de caracters para o WEB API.    
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new GrupoUsuarioMapping());
            modelBuilder.Configurations.Add(new UsuarioMapping());
            modelBuilder.Configurations.Add(new CongregacaoMapping());
            modelBuilder.Configurations.Add(new CaixaMapping());
            modelBuilder.Configurations.Add(new CaixaUsuarioMapping());
            modelBuilder.Configurations.Add(new CidadeMapping());
            modelBuilder.Configurations.Add(new EstadoMapping());
            modelBuilder.Configurations.Add(new EnderecoMapping());
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<GrupoUsuario> GrupoUsuario { get; set; }
        public DbSet<Congregacao> Congregacao { get; set; }
        public DbSet<CaixaUsuario> CaixaUsuario { get; set; }
        public DbSet<Caixa> Caixa { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Estado> Estado { get; set; }

    }
}

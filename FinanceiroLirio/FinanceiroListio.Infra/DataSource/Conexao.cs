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
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<GrupoUsuario> GrupoUsuario { get; set; }
    }
}

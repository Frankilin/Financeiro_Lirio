using FinanceiroLirio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroListio.Infra.Mappings
{
    public class GrupoUsuarioMapping : EntityTypeConfiguration<GrupoUsuario>
    {
        public GrupoUsuarioMapping()
        {
            HasKey(g => g.IdGrupoUsuario);

            Property(g => g.IdGrupoUsuario)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(g => g.Descricao)
                .HasMaxLength(50)
                .IsRequired();
            
        }
    }
}

using FinanceiroLirio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FinanceiroListio.Infra.Mappings
{
    public class CaixaUsuarioMapping : EntityTypeConfiguration<CaixaUsuario>
    {
        public CaixaUsuarioMapping()
        {
            HasKey(c => c.IdCaixaUsuario);

            Property(c => c.IdCaixaUsuario)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.DataInclusao)
                .IsRequired();

            HasRequired(c => c.Caixa)
                .WithMany()
                .HasForeignKey(c => c.IdCaixa);

            HasRequired(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.IdUsuario);
        }
    }
}

using FinanceiroLirio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FinanceiroLirio.Infra.Mappings
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

            Property(c => c.IdCaixa)
                .IsRequired();

            Property(c => c.IdUsuario)
                .IsRequired();

            HasRequired(c => c.Caixa)
                .WithMany(x => x.CaixaUsuario)
                .HasForeignKey(c => c.IdCaixa);

            HasRequired(c => c.Usuario)
                .WithMany(u => u.CaixaUsuario)
                .HasForeignKey(c => c.IdUsuario);
        }
    }
}

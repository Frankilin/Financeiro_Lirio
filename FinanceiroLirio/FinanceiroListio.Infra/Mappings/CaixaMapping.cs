using FinanceiroLirio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace FinanceiroListio.Infra.Mappings
{
    public class CaixaMapping : EntityTypeConfiguration<Caixa>
    {
        public CaixaMapping()
        {
            HasKey(c => c.IdCaixa);

            Property(c => c.IdCaixa)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, 
                    new IndexAnnotation(new IndexAttribute("IDX_DescCaixa") { IsUnique = true}));

            Property(c => c.SaldoInicial)
                .IsRequired();

            Property(c => c.DataInclusao)
                .IsRequired();

            HasRequired(c => c.Congregacao)
                .WithMany(x => x.Caixa)
                .HasForeignKey(c => c.IdCongregacao);
        }
    }
}

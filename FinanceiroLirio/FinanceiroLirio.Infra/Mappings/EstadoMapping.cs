using FinanceiroLirio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace FinanceiroLirio.Infra.Mappings
{
    public class EstadoMapping : EntityTypeConfiguration<Estado>
    {
        public EstadoMapping()
        {
            HasKey(e => e.IdEstado);

            Property(e => e.IdEstado)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Nome)
                .HasMaxLength(40)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IDX_NOMEESTADO") { IsUnique = true }));
        }
    }
}

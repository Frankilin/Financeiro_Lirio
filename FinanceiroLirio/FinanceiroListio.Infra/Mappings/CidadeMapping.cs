using FinanceiroLirio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace FinanceiroListio.Infra.Mappings
{
    public class CidadeMapping : EntityTypeConfiguration<Cidade>
    {
        public CidadeMapping()
        {
            HasKey(c => c.IdCidade);

            Property(c => c.IdCidade)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Nome)
                .HasMaxLength(150)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IDX_NOMECIDADE") { IsUnique = true }));

            HasRequired(c => c.Estado)
                .WithMany(c => c.Cidade)
                .HasForeignKey(c => c.IdEstado);

            HasRequired(c => c.Endereco)
                .WithMany()
                .Map
        }
    }
}

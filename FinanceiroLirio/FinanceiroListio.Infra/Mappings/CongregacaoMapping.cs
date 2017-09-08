using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using FinanceiroLirio.Entidades;

namespace FinanceiroListio.Infra.Mappings
{
    class CongregacaoMapping:EntityTypeConfiguration<Congregacao>
    {
        public CongregacaoMapping()
        {
            //Id congregação - AutoIncremento/ Identity
            HasKey(c => c.IdCongregacao);
            Property(c => c.IdCongregacao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Descrição 
            Property(c => c.Descricao)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IDX_DESCRICAO") { IsUnique = true }));

            //Apelido
            Property(c => c.Apelido)
                .HasMaxLength(30)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IDX_APELIDO") { IsUnique = true }));

            //Ativo
            Property(c => c.Ativo)
                .IsRequired();

            //Data Inclusão
            Property(c => c.DataInclusao)
                .IsRequired();

            //Data ID Endereço
            Property(c => c.IdEndereco)
                .IsRequired();
            
            //Relacionamento com a tabela Endereço 
            HasRequired(c => c.Endereco)
                .WithMany()
                .HasForeignKey(c => c.IdEndereco);
        }
    }
}

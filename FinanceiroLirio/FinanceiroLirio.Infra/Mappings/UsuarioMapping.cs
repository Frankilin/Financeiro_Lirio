using FinanceiroLirio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroLirio.Infra.Mappings
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapping()
        {
            HasKey(u => u.IdUsuario);

            Property(u => u.IdUsuario)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(u => u.NomeCompleto)
                .HasMaxLength(120)
                .IsRequired();

            Property(u => u.Login)
                .HasMaxLength(40)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IDX_LOGIN") { IsUnique = true }));

            Property(u => u.Senha)
                .HasMaxLength(32)
                .IsRequired();

            Property(u => u.Email)
                .HasMaxLength(120)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IDX_EMAIL") { IsUnique = true }));

            Property(u => u.Ativo)
                .IsRequired();

            //Property(u => u.IdCargo)
            //    .IsRequired();

            Property(u => u.IdGrupoUsuario)
                .IsRequired();

            //Property(u => u.IdSetor)
            //    .IsRequired();

            Property(u => u.DataCadastro)
                .IsRequired();

            HasRequired(u => u.GrupoUsuario)
                .WithMany(g => g.Usuario)
                .HasForeignKey(u => u.IdGrupoUsuario);

        }
    }
}

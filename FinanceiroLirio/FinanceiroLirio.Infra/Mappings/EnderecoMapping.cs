﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using FinanceiroLirio.Entidades;

namespace FinanceiroLirio.Infra.Mappings
{
    class EnderecoMapping: EntityTypeConfiguration<Endereco>
    {
        public EnderecoMapping()
        {
            HasKey(e => e.IdEndereco);

            Property(e => e.IdEndereco)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Rua
            Property(e => e.Rua)
                .HasMaxLength(120);

            //Numero
            Property(e => e.Numero)
                .HasMaxLength(5);

            //Complemento
            Property(e => e.Complemento)
                .HasMaxLength(100);

            //Cep
            Property(e => e.Cep)
                .HasMaxLength(8);

            //Bairro
            Property(e => e.Bairro)
                .HasMaxLength(50);

            //IdCidade
            Property(e => e.IdCidade)
                .IsRequired();

            HasRequired(e => e.Cidade)
                .WithMany(c => c.Endereco)
                .HasForeignKey(e => e.IdCidade);

        }
    }
}

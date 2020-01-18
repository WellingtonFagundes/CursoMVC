using EP.CursoMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Infra.Data.Mappings
{
    public class EnderecoMapping:EntityTypeConfiguration<Endereco>
    {
        public EnderecoMapping()
        {
            HasKey(e => e.Id);

            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(300);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(20);

            Property(e => e.Complemento)
                .IsRequired()
                .HasMaxLength(100);

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();


            //ONE TO ONE OR ZERO: HasOptional
            //ONE TO ONE
            //ONE TO MANY OR ZERO
            //MANY TO MANY

            HasRequired(c => c.Cliente)
               .WithMany(c => c.Enderecos)
               .HasForeignKey(e => e.ClienteId);

            ToTable("Enderecos");
        }
    }
}

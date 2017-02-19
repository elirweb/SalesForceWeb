using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SalesForceWeb.Repository.EntityTypeConfigurations
{
    public class EnderecoConfiguration: EntityTypeConfiguration<SalesForceWeb.Domain.Entities.Endereco>
    {
        public EnderecoConfiguration()
        {
            ToTable("Endereco");
            HasKey(c=>c.Id);
            Property(c => c.Id).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("IDEndereco");
            Property(c => c.Logradouro).HasColumnType("VARCHAR").HasMaxLength(200);
            Property(c => c.Numero).HasColumnType("VARCHAR").HasMaxLength(10);
            Property(c => c.Cidade).HasColumnType("VARCHAR").HasMaxLength(100);
            Property(c => c.Uf);

            Property(c => c.DtAlteracao).HasColumnType("DATE");
            Property(c => c.DtInclusao).HasColumnType("DATE");

            // 1 para 1
            HasRequired(x => x.UsuarioModel)
                               .WithMany()
                               .HasForeignKey(x => x.IDUsuario);


        }
    }
}

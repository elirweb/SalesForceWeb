using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SalesForceWeb.Repository.EntityTypeConfigurations
{
    public class UsuarioConfiguration: EntityTypeConfiguration<SalesForceWeb.Domain.Entities.Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("Usuario");
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("IDUsuario");

            Property(c => c.Nome).HasColumnType("VARCHAR").HasMaxLength(100);
            Property(c => c.SobreNome).HasColumnType("VARCHAR").HasMaxLength(50);
            Property(c => c.Sexo).HasColumnType("VARCHAR").HasMaxLength(10);
            Property(c => c.Idade).HasColumnType("VARCHAR").HasMaxLength(4);
            Property(c => c.Email.Endereco).HasColumnType("VARCHAR").HasMaxLength(100);

            
            Property(c => c.Senha).HasColumnType("VARCHAR").HasMaxLength(300);

            Property(c => c.TokenAlteracaoDeSenha).HasColumnName("Token").HasColumnType("VARCHAR");
            Property(c => c.Hora).HasColumnType("VARCHAR").HasMaxLength(5);
            Property(c => c.DtAlteracao).HasColumnType("DATE");
            Property(c => c.DtInclusao).HasColumnType("DATE");

        }
    }
}

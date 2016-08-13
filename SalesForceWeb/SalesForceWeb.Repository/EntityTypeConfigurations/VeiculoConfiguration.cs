using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SalesForceWeb.Repository.EntityTypeConfigurations
{
    public class VeiculoConfiguration:EntityTypeConfiguration<SalesForceWeb.Domain.Entities.Veiculo>
    {
        public VeiculoConfiguration()
        {
            ToTable("Veiculo");
            HasKey(c=>c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("IDVeiculo");
            Property(c => c.Nome).HasColumnName("Nome").HasColumnType("VARCHAR").HasMaxLength(200);

            HasRequired(c => c.ModeloModel).WithMany().
                HasForeignKey(c => c.CodigoModelo);

            Property(c => c.Ano).HasColumnType("VARCHAR").HasMaxLength(10);
            Property(c=>c.Cor).HasColumnType("VARCHAR").HasMaxLength(50);

            HasRequired(c => c.TipoModel).WithMany().HasForeignKey(c => c.CodigoTipo);
            Property(c=>c.Renavam).HasColumnType("VARCHAR").HasMaxLength(90);

            Property(c => c.Placa).HasMaxLength(10).HasColumnType("VARCHAR");
            Property(c => c.DtAlteracao).HasColumnType("DATE");
            Property(c => c.DtInclusao).HasColumnType("DATE");
        }
    }
}

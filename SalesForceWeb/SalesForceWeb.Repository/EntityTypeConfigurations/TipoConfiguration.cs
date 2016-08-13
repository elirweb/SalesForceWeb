using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SalesForceWeb.Repository.EntityTypeConfigurations
{
    public class TipoConfiguration:EntityTypeConfiguration<SalesForceWeb.Domain.Entities.Tipo>
    {
        public TipoConfiguration()
        {
            ToTable("Tipo");
            HasKey(c=>c.Id);

            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("IDTipo");
            Property(c => c.TipoVeiculo).HasColumnName("Tipo").HasMaxLength(100).HasColumnType("VARCHAR");
        }
    }
}

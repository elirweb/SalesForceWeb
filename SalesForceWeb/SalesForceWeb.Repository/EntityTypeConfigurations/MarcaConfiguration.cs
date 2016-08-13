using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SalesForceWeb.Repository.EntityTypeConfigurations
{
    public class MarcaConfiguration: EntityTypeConfiguration<SalesForceWeb.Domain.Entities.Marca>
    {
        public MarcaConfiguration()
        {
            ToTable("Marca");
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("IDMarca");
            Property(c=>c.Nome).HasColumnName("Nome").HasColumnType("VARCHAR");

        }
    }
}

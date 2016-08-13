using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SalesForceWeb.Repository.EntityTypeConfigurations
{
    public class ModeloConfiguration: EntityTypeConfiguration<SalesForceWeb.Domain.Entities.Modelo>
    {
        public ModeloConfiguration()
        {
            ToTable("Modelo");
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("IDModelo");
            Property(c => c.Nome).HasColumnType("VARCHAR").HasMaxLength(100);

            HasRequired(c => c.MarcaModel).WithMany().HasForeignKey(c=>c.IDMarca);
    }
}
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SalesForceWeb.Repository.EntityTypeConfigurations
{
    internal class ItensConfiguration : EntityTypeConfiguration<SalesForceWeb.Domain.Entities.Itens>
    {
        public ItensConfiguration()
        {
            ToTable("Itens");
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("IDItens");

            HasRequired(c => c.VeiculoModel).WithMany().HasForeignKey(c => c.CodigoVeiculo);
            HasRequired(c => c.VendaModel).WithMany().HasForeignKey(c => c.CodigoVenda);
            Property(c => c.Preco).HasColumnName("Preco").HasColumnType("Decimal").HasPrecision(18,2);
                  
    
    
    }
}
}
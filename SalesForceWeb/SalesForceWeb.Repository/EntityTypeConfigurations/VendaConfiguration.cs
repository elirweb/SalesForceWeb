using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SalesForceWeb.Repository.EntityTypeConfigurations
{
    public class VendaConfiguration: EntityTypeConfiguration<SalesForceWeb.Domain.Entities.Venda>
    {
        public VendaConfiguration()
        {
            ToTable("Venda");
            HasKey(c=>c.Id);

       
     Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("IDVenda");
            Property(c => c.TokenVenda).HasColumnType("VARCHAR");

            HasRequired(c => c.UsuarioModel).WithMany().
                HasForeignKey(c => c.IDUsuario);

            Property(c => c.PrecoVenda).HasColumnType("Decimal").HasColumnName("Preco").HasPrecision(18,2); 
    
    }
}
}

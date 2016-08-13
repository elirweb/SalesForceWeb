using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SalesForceWeb.Repository.EFDataBase
{
    public class Contexto: DbContext
    {
        public Contexto(): base("Contexto")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            
        }
        public DbSet<SalesForceWeb.Domain.Entities.Usuario> Usuario {get;set;}
        public DbSet<SalesForceWeb.Domain.Entities.Documento> Documento { get; set; }
        public DbSet<SalesForceWeb.Domain.Entities.Tipo> Tipo { get; set; }
        public DbSet<SalesForceWeb.Domain.Entities.Modelo> Modelo { get; set; }
        public DbSet<SalesForceWeb.Domain.Entities.Veiculo> veiculo { get; set; }
        public DbSet<SalesForceWeb.Domain.Entities.Venda> Venda { get; set; }

        public DbSet<SalesForceWeb.Domain.Entities.Endereco> Endereco { get; set; }
        public DbSet<SalesForceWeb.Domain.Entities.Itens> Itens { get; set; }
        public DbSet<SalesForceWeb.Domain.Entities.Marca> Marca { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new EntityTypeConfigurations.UsuarioConfiguration());
            modelBuilder.Configurations.Add(new EntityTypeConfigurations.DocumentoConfiguration());
            modelBuilder.Configurations.Add(new EntityTypeConfigurations.ModeloConfiguration());
            modelBuilder.Configurations.Add(new EntityTypeConfigurations.TipoConfiguration());
            modelBuilder.Configurations.Add(new EntityTypeConfigurations.VendaConfiguration());
            modelBuilder.Configurations.Add(new EntityTypeConfigurations.VeiculoConfiguration());
            modelBuilder.Configurations.Add(new EntityTypeConfigurations.ItensConfiguration());
            modelBuilder.Configurations.Add(new EntityTypeConfigurations.EnderecoConfiguration());
            modelBuilder.Configurations.Add(new EntityTypeConfigurations.MarcaConfiguration());

            
        }
    }
}

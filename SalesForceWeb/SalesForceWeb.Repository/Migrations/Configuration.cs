namespace SalesForceWeb.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Seed;
    internal sealed class Configuration : DbMigrationsConfiguration<SalesForceWeb.Repository.EFDataBase.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SalesForceWeb.Repository.EFDataBase.Contexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //Usuario.UsuarioSeed(context);
            //Documento.DocumentoSeed(context);
            //Marca.MarcaSeed(context);
            //Modelo.ModeloSeed(context);
            //Endereco.EnderecoSeed(context);

            //Tipo.TipoSeed(context);
            //Veiculo.VeiculoSeed(context);

            //Venda.VendaSeed(context);
            Itens.ItensSeed(context);
        }
    }
}

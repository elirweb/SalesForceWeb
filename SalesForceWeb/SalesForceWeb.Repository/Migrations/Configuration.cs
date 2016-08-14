namespace SalesForceWeb.Repository.Migrations
{
    using System.Data.Entity.Migrations;
    using Seed;
    internal sealed class Configuration : DbMigrationsConfiguration<EFDataBase.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(EFDataBase.Contexto context)
        {
            //Marca.MarcaSeed(context);
            Modelo.ModeloSeed(context);
        }
    }
}

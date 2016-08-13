namespace SalesForceWeb.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Seed;
    internal sealed class Configuration : DbMigrationsConfiguration<EFDataBase.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(EFDataBase.Contexto context)
        {
            Marca.MarcaSeed(context);
        }
    }
}

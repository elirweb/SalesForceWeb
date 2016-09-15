using SalesForceWeb.Repository.Seed;
namespace SalesForceWeb.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFDataBase.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

       
        protected override void Seed(EFDataBase.Contexto context)
        {
            //Marca.MarcaSeed(context);
            //Modelo.ModeloSeed(context);

            //context.veiculo.AddOrUpdate(new Domain.Entities.Veiculo { Id = 3, CodigoModelo = 1, CodigoTipo = 2, Ano = DateTime.Now.Year.ToString(), Cor = "Amarelo", Placa = "XTR-9305", Renavam = "30250403", DtInclusao = DateTime.Now, DtAlteracao = DateTime.Now    });
            //context.veiculo.AddOrUpdate(new Domain.Entities.Veiculo { Id = 4, CodigoModelo = 3, CodigoTipo = 3, Ano = DateTime.Now.Year.ToString(), Cor = "Cinza", Placa = "VQR-0103", Renavam = "8912349430", DtInclusao = DateTime.Now, DtAlteracao = DateTime.Now });
            
            
        }
    }
}

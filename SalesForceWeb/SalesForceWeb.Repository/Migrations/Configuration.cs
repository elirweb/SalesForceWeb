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

            context.Tipo.AddOrUpdate(new Domain.Entities.Tipo { Id = 1, TipoVeiculo = "Carro", DtInclusao = DateTime.Now, DtAlteracao = DateTime.Now });
            context.veiculo.AddOrUpdate(new Domain.Entities.Veiculo { Id = 1, CodigoModelo = 2, CodigoTipo = 1, Ano = DateTime.Now.Year.ToString(), Cor = "Prata", Placa = "FLT-0798", Renavam = "1234567", DtInclusao = DateTime.Now, DtAlteracao = DateTime.Now    });
            
        }
    }
}

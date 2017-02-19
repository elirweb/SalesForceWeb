using System;
using System.Data.Entity.Migrations;

namespace SalesForceWeb.Repository.Seed
{
    public class Veiculo
    {
        public static void VeiculoSeed(SalesForceWeb.Repository.EFDataBase.Contexto contexto)
        {
         contexto.veiculo.AddOrUpdate(
         new Domain.Entities.Veiculo {

             CodigoModelo = 1,
             Ano = "2012",
             Cor = "Preto",
            CodigoTipo = 9,
            Renavam = "43434344",
            Placa = "EFR-2567",
            DtInclusao = DateTime.Now.Date,
            DtAlteracao = DateTime.Now.Date


         });

            contexto.veiculo.AddOrUpdate(
                     new Domain.Entities.Veiculo
                     {

                         CodigoModelo = 7,
                         Ano = "2015",
                         Cor = "Azul",
                         CodigoTipo = 9,
                         Renavam = "43434344",
                         Placa = "FLT-0798",
                         DtInclusao = DateTime.Now.Date,
                         DtAlteracao = DateTime.Now.Date
                     });

            contexto.veiculo.AddOrUpdate(
                     new Domain.Entities.Veiculo
                     {

                         CodigoModelo = 9,
                         Ano = "2010",
                         Cor = "Branco",
                         CodigoTipo = 9,
                         Renavam = "3465666",
                         Placa = "TGE-0523",
                         DtInclusao = DateTime.Now.Date,
                         DtAlteracao = DateTime.Now.Date

                     });


        }

    }
}

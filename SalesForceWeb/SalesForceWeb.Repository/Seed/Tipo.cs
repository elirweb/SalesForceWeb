using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesForceWeb.Repository.Seed
{
    public class Tipo
    {

        public static void TipoSeed(SalesForceWeb.Repository.EFDataBase.Contexto contexto)
        {
            contexto.Tipo.AddOrUpdate(
            new Domain.Entities.Tipo
            {
                TipoVeiculo = "Carro",
                DtInclusao = DateTime.Now.Date,
                DtAlteracao = DateTime.Now.Date
            });

            contexto.Tipo.AddOrUpdate(
           new Domain.Entities.Tipo
           {
               TipoVeiculo = "Moto",
               DtInclusao = DateTime.Now.Date,
               DtAlteracao = DateTime.Now.Date
           });

            contexto.Tipo.AddOrUpdate(
           new Domain.Entities.Tipo
           {
               TipoVeiculo = "Caminhão",
               DtInclusao = DateTime.Now.Date,
               DtAlteracao = DateTime.Now.Date
           });
        }
    }
}   


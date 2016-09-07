using System;
using System.Data.Entity.Migrations;

namespace SalesForceWeb.Repository.Seed
{
    public class Modelo
    {
        public static void ModeloSeed(SalesForceWeb.Repository.EFDataBase.Contexto contexto) {



            contexto.Modelo.AddOrUpdate(
              new Domain.Entities.Modelo
              {
                  Nome = "Novo Fiesta",
                  IDMarca = 1,
                  DtInclusao = DateTime.Now.Date,
                  DtAlteracao = DateTime.Now.Date,
                  
              });
            
            contexto.Modelo.AddOrUpdate(
              new Domain.Entities.Modelo
              {
                  Nome = "Corsa Classic 1.0",
                  IDMarca = 6,
                  DtAlteracao = DateTime.Now.Date,
                  DtInclusao = DateTime.Now.Date
              });

            contexto.Modelo.AddOrUpdate(
              new Domain.Entities.Modelo
              {
                  Nome = "Meriva",
                  IDMarca = 6,
                  DtAlteracao = DateTime.Now.Date,
                  DtInclusao = DateTime.Now.Date
              });

            contexto.Modelo.AddOrUpdate(
              new Domain.Entities.Modelo
              {
                  Nome = "Premiun",
                  IDMarca = 6,
                  DtAlteracao = DateTime.Now.Date,
                  DtInclusao = DateTime.Now.Date
              });

            contexto.Modelo.AddOrUpdate(
              new Domain.Entities.Modelo
              {
                  Nome = "Vectra",
                  IDMarca = 6,
                  DtAlteracao = DateTime.Now.Date,
                  DtInclusao = DateTime.Now.Date
              });

            contexto.Modelo.AddOrUpdate(
              new Domain.Entities.Modelo
              {
                  Nome = "Honda Cit",
                  IDMarca = 7,
                  DtAlteracao = DateTime.Now.Date,
                  DtInclusao = DateTime.Now.Date
              });

            contexto.Modelo.AddOrUpdate(
              new Domain.Entities.Modelo
              {
                  Nome = "CRV",
                  IDMarca = 7,
                  DtAlteracao = DateTime.Now.Date,
                  DtInclusao = DateTime.Now.Date
              });

            

            contexto.Modelo.AddOrUpdate(
              new Domain.Entities.Modelo
              {
                  Nome = "Palio",
                  IDMarca = 2,
                  DtAlteracao = DateTime.Now.Date,
                  DtInclusao = DateTime.Now.Date
              });

            contexto.Modelo.AddOrUpdate(
              new Domain.Entities.Modelo
              {
                  Nome = "Fiat Uno",
                  IDMarca = 2,
                  DtAlteracao = DateTime.Now.Date,
                  DtInclusao = DateTime.Now.Date
              });
            contexto.Modelo.AddOrUpdate(
              new Domain.Entities.Modelo
              {
                  Nome = "Palio Weekend",
                  IDMarca = 6,
                  DtAlteracao = DateTime.Now.Date,
                  DtInclusao = DateTime.Now.Date
              });

        }
    }
}

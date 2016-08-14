using System;
using System.Data.Entity.Migrations;

namespace SalesForceWeb.Repository.Seed
{
    public class Marca
    {
        public static void MarcaSeed(SalesForceWeb.Repository.EFDataBase.Contexto 
            contexto)
        {
            contexto.Marca.AddOrUpdate( 
                new Domain.Entities.Marca { Nome = "Ford", DtInclusao = DateTime.Now, DtAlteracao = DateTime.Now  } );

            contexto.Marca.AddOrUpdate(
                new Domain.Entities.Marca { Nome = "Fiat", DtInclusao = DateTime.Now, DtAlteracao = DateTime.Now });

            contexto.Marca.AddOrUpdate(
                            new Domain.Entities.Marca { Nome = "Volkswagem", DtInclusao = DateTime.Now, DtAlteracao = DateTime.Now });
            contexto.Marca.AddOrUpdate(
                            new Domain.Entities.Marca { Nome = "Renault", DtInclusao = DateTime.Now, DtAlteracao = DateTime.Now });
            contexto.Marca.AddOrUpdate(
                            new Domain.Entities.Marca { Nome = "Cienna", DtInclusao = DateTime.Now, DtAlteracao = DateTime.Now });
            contexto.Marca.AddOrUpdate(
                            new Domain.Entities.Marca { Nome = "Chevrolet", DtInclusao = DateTime.Now, DtAlteracao = DateTime.Now });

            contexto.Marca.AddOrUpdate(
                           new Domain.Entities.Marca { Nome = "Honda", DtInclusao = DateTime.Now, DtAlteracao = DateTime.Now });
            
            contexto.Marca.AddOrUpdate(
                          new Domain.Entities.Marca { Nome = "Pegeout", DtInclusao = DateTime.Now, DtAlteracao = DateTime.Now });

        }

    }
}

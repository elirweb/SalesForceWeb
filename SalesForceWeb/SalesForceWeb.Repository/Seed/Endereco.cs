using System;
using System.Data.Entity.Migrations;

namespace SalesForceWeb.Repository.Seed
{
    public class Endereco
    {
        public static void EnderecoSeed(SalesForceWeb.Repository.EFDataBase.Contexto contexto) {

            contexto.Endereco.AddOrUpdate(
            new Domain.Entities.Endereco {

                Cidade = "São Paulo",
                Logradouro = "Guaianazes",
                Numero = "103",
                IDUsuario = 1,
                DtInclusao = DateTime.Now.Date,
                Uf = Domain.Enum.Uf.SP

            });


    }
    }
}

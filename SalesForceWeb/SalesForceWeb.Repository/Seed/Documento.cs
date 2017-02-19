using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesForceWeb.Repository.Seed
{
    public class Documento
    {
        public static void DocumentoSeed(SalesForceWeb.Repository.EFDataBase.Contexto contexto)
        {

            contexto.Documento.AddOrUpdate(
        new Domain.Entities.Documento
        {

            RG = new  Domain.ValuesObject.RG("411798923"),
            CPF = new Domain.ValuesObject.Cpf("35717357818"),
            Id = 2,
            IDUsuario = 1,
            DtInclusao = DateTime.Now.Date
            }
        );

        }
    }
}

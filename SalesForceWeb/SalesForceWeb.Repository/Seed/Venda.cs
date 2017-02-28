using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesForceWeb.Repository.Seed
{
    public class Venda
    {
        public static void VendaSeed(SalesForceWeb.Repository.EFDataBase.Contexto contexto)
        {
            contexto.Venda.AddOrUpdate(
                new Domain.Entities.Venda
                {
                    TokenVenda = Guid.NewGuid().ToString(),
                    IDUsuario = 1,
                    PrecoVenda = 35.000m,
                    DtInclusao = DateTime.Now.Date
             
                }
                );
        }
    }
}

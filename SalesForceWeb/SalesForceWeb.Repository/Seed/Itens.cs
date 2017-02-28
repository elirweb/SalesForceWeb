using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesForceWeb.Repository.Seed
{
    public class Itens
    {
        public static void ItensSeed(SalesForceWeb.Repository.EFDataBase.Contexto contexto) {

            contexto.Itens.AddOrUpdate(
                new Domain.Entities.Itens {
                    CodigoVeiculo = 8,
                    CodigoVenda = 1,
                    Preco = 35.00000m,
                    DtInclusao = DateTime.Now.Date
                }
                );

            
        }
    }
}

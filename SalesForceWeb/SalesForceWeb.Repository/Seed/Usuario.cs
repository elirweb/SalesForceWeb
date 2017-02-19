using System;
using System.Data.Entity.Migrations;

namespace SalesForceWeb.Repository.Seed
{
    public class Usuario
    {
        public static void UsuarioSeed(SalesForceWeb.Repository.EFDataBase.Contexto contexto)
        {
            contexto.Usuario.AddOrUpdate(
           new Domain.Entities.Usuario
           {
               Nome = "Elir",
               SobreNome = "Ribeiro",
               Idade = "29",
               Email = new Domain.ValuesObject.Email("elirweb@gmail.com"),
               Login = "elirweb",
               Senha = "1234",
               Sexo = "M",
               Hora = DateTime.Now.ToShortTimeString(),
               TokenAlteracaoDeSenha = Guid.NewGuid().ToString(),
               DtInclusao = DateTime.Now.Date


           });
        }
    }
}

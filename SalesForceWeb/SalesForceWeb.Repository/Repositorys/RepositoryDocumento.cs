using System;
using System.Linq;
using SalesForceWeb.Domain.Entities;
using SalesForceWeb.Domain.Interfaces;
using SalesForceWeb.Domain.ValuesObject;
using SalesForceWeb.Repository.EFDataBase;

namespace SalesForceWeb.Repository.Repositorys
{
    public class RepositoryDocumento : RepositoryBase<SalesForceWeb.Domain.Entities.Documento>,IDocumento
    {

        private readonly Repository.EFDataBase.Contexto _contexto;
        private readonly Repository.Repositorys.RepositoryDocumento _documento = null;
        public RepositoryDocumento(Contexto contexto_): base (new Contexto())
        {
            _contexto = contexto_;

        }
        
        public bool CPFJaCadastrado(Cpf cpf, int usuarioid)
        {
            return _documento.Get().Any(x=>x.CPF.Codigo == cpf.Codigo && 
                            x.Id != usuarioid);
        }
    }
}

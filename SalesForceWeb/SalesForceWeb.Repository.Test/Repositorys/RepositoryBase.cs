using System.Collections.Generic;
using System.Linq;
using SalesForceWeb.Domain.Test.Entities;
using SalesForceWeb.Repository.Test.EFDataBase;

namespace SalesForceWeb.Repository.Test.Repositorys
{
    public class RepositoryBase
    {
        private Contexto _contexto { get; set; }

        public RepositoryBase(Contexto contexto_)
        {
            _contexto = contexto_;
            
        }

        public List<Documento> Retornar() {
            return _contexto.Documentos.Where(a => a.Id == 1).ToList();
        }

        public void Salvar(Marca documentos) {
            _contexto.Marca.Add(documentos);
            _contexto.SaveChanges();
        }
    }
}

using System;

namespace SalesForceWeb.Domain.Entities
{
    public  class Modelo:Base.EntidadeBase
    {
        public string Nome { get; set; }
        public int IDMarca { get; set; }
        public virtual Marca MarcaModel { get; set; }
    }
}
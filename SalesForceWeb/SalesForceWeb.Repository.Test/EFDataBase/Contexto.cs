using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesForceWeb.Domain.Test.Entities;

namespace SalesForceWeb.Repository.Test.EFDataBase
{
    public class Contexto : DbContext
    {
            public virtual DbSet<Documento> Documentos { get; set; }
            public virtual DbSet<Marca> Marca { get; set; }

     } 
}


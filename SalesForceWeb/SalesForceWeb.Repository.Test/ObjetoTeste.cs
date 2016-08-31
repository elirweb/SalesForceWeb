using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SalesForceWeb.Domain.Test.Entities;
using SalesForceWeb.Repository.Test.EFDataBase;
using SalesForceWeb.Repository.Test.Repositorys;

namespace SalesForceWeb.Repository.Test
{

    [TestClass]
    public class ObjetoTeste
    {
         
        [TestMethod]
        public void carregar() {
            var mockdoc = new Mock<DbSet<Marca>>(); // mokando todos os DbContext no Contexto

            var mockdados = new Mock<Contexto>();
            mockdados.Setup(dc => dc.Marca).Returns(mockdoc.Object);

            var dados = new RepositoryBase(mockdados.Object); // chamando o repository base 

            // adicionando os dados
            dados.Salvar(new Marca { Id = 20, Nome = "Teste TDD" , DtInclusao = DateTime.Now,
                 DtAlteracao = DateTime.Now});
            
            // verificando se tem apenas uma Marca e usando o Times once chamar uma vez aplicação
            mockdoc.Verify(m => m.Add(It.IsAny<Marca>()), Times.Once());

            // verificando se foi passado uma vez a aplicação
            mockdados.Verify(mc=>mc.SaveChanges(),Times.Once());

            
        }

    }
}

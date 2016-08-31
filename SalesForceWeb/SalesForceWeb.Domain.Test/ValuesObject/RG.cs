using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalesForceWeb.Domain.Test.ValuesObject
{
    [TestClass]
    public class RG
    {
        private string v;

        public string CodigoRG { get; set; }
        public RG() { }

        public RG(string v)
        {
            this.CodigoRG = v;
        }

        [TestMethod]
        [TestCategory("RG_EM_BRANCO")]
        public void RG_EM_BRANCO() {
            var rg = new RG("4545545545");
            Assert.AreEqual("4545545545", rg.CodigoRG,"RG em Branco");
        }

        
    }
}

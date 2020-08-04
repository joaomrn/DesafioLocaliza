using DecompositorNumerico.Dominio;
using DecompositorNumerico.Servico;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecompositorNumerico.Teste
{
    [TestClass]
    public class TestarDivisores
    {
        [TestMethod]
        public void TestarDivisoresEPrimos()
        {
            int sucesso = 0;
            try
            {
                Divisores divisores = new Divisores();
                Divisor resposta = divisores.Calcular(40);
                sucesso = 1;
            }
            catch (System.Exception)
            {
                sucesso = 0;
            }

            Assert.AreEqual(sucesso, 1);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoAnalizadorLéxico.logica;
using System.IO;

namespace ProyectoAnalizadorLéxico.Pruebas
{
    [TestClass]
    public class PruebasAnalizador
    {
        private AnalizadorLexico analizador;

        [TestInitialize]
        public void Setup()
        {
            analizador = new AnalizadorLexico();
        }

        [TestMethod]
        public void Validar_ArchivoInicial1_NoGeneraErrores()
        {
            
            string ruta = @"archivos_prueba\inicial1.txt";
            string codigo = File.ReadAllText(ruta);

            
            analizador.Analizar(codigo);
            var errores = analizador.ObtenerErrores();
            var tokens = analizador.ObtenerTokens();

            
            Assert.AreEqual(0, errores.Count, "El archivo inicial1.txt no debería contener errores léxicos.");
            Assert.IsTrue(tokens.Count > 0, "Se debieron generar tokens válidos.");
        }

        [TestMethod]
        public void Validar_ArchivoError1_ContinuaEscaneo()
        {
            
            string ruta = @"archivos_prueba\error1.txt";
            string codigo = File.ReadAllText(ruta);

            
            analizador.Analizar(codigo);
            var errores = analizador.ObtenerErrores();
            var tokens = analizador.ObtenerTokens();

            
            Assert.IsTrue(errores.Count > 0, "Se esperaba detectar errores en error1.txt.");
            Assert.IsTrue(tokens.Count > 0, "El analizador se detuvo en el error y no extrajo los tokens válidos restantes.");
        }
    }
}
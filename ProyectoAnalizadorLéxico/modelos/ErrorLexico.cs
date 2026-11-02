using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAnalizadorLéxico.logica
{
    public class ErrorLexico
    {
        public string CaracterCadena { get; set; }
        public int Linea {  get; set; }
        public int Columna { get; set; }
        public string Descripcion { get; set; }

        public ErrorLexico(string caracter, int linea, int columna, string descripcion)
        {
            CaracterCadena = caracter;
            Linea = linea;
            Columna = columna;
            Descripcion = descripcion;
        }
    }
}

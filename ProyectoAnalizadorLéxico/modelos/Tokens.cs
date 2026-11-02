using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAnalizadorLéxico.logica
{

    public enum TipoToken
    {
        Identificador,
        NumeroEntero,
        PalabraReservada,
        OperadorAsignacion,

    }

    public class Token
    {

        public string Tipo { get; set; }
        public string Valor { get; set; }
        public int Linea { get; set; }
        public int Columna { get; set; }

        public Token(string lexema, string tipo, int linea, int columna)
        {
            Valor = lexema;
            Tipo = tipo;
            Linea = linea;
            Columna = columna;
        }
    }    

    


}
    


    








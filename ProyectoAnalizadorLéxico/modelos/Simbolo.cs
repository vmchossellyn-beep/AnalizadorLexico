using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAnalizadorLéxico.modelos
{
    public class Simbolo
    {
        public string Name { get; set; }
        public string SymbolKind { get; set; }
        public string DataType { get; set; }
        public int ScopeLevel { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }

    }
}

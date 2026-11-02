using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoAnalizadorLéxico.modelos;

namespace ProyectoAnalizadorLéxico.logica
{

    public class TablaDeSimbolos
    {
        private Dictionary<string, Simbolo> simbolos = new Dictionary<string, Simbolo>();

        public bool AgregarSimbolo(Simbolo s)
        {
            if (!simbolos.ContainsKey(s.Name))
            {
                simbolos.Add(s.Name, s);
                return true;
            }

            return false;
        }
        public Simbolo BuscarSimbolo(string nombre)
        {
            if (simbolos.ContainsKey(nombre))
            {
                return simbolos[nombre];
            }
            return null;
        }

        public List<Simbolo> ObtenerLista()
        {
            return simbolos.Values.ToList();
        }

    }
}

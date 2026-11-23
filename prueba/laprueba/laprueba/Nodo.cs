using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laprueba
{
    internal class Nodo
    {
        public Transferencia Dato { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }
        public int Altura { get; set; }
        public Nodo(Transferencia dato)
        {
            Dato = dato;
            Izquierdo = null;
            Derecho = null;
            Altura = 1;
        }
    }
}

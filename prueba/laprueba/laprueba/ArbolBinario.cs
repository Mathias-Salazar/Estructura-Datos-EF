using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laprueba
{
    internal class ArbolBinario
    {
        private Nodo raiz;
        public void InsertarTransferencia(Transferencia transferencia)
        {
            raiz = InsertarRecursivo(raiz, transferencia);
        }

        private Nodo InsertarRecursivo(Nodo nodo, Transferencia transferencia)
        {
            if (nodo == null)
            {
                return new Nodo(transferencia);
            }

            if (transferencia.Codigo < nodo.Dato.Codigo)
            {
                nodo.Izquierdo = InsertarRecursivo(
                    nodo.Izquierdo, transferencia);
            }
            else if (transferencia.Codigo > nodo.Dato.Codigo)
            {
                nodo.Derecho = InsertarRecursivo(
                    nodo.Derecho, transferencia);
            }
            else
            {
                throw new InvalidOperationException(
                    "Ya existe una transferencia con ese código.");
            }
            ActualizarAltura(nodo);

            int balance = ObtenerBalance(nodo);

            if (balance > 1 && transferencia.Codigo < nodo.Izquierdo.Dato.Codigo)
            {
                return RotarDerecha(nodo);
            }

            if (balance < -1 &&transferencia.Codigo > nodo.Derecho.Dato.Codigo)
            {
                return RotarIzquierda(nodo);
            }

            if (balance > 1 &&
                transferencia.Codigo > nodo.Izquierdo.Dato.Codigo)
            {
                nodo.Izquierdo = RotarIzquierda(nodo.Izquierdo);
                return RotarDerecha(nodo);
            }

            // Caso derecha - izquierda
            if (balance < -1 &&
                transferencia.Codigo < nodo.Derecho.Dato.Codigo)
            {
                nodo.Derecho = RotarDerecha(nodo.Derecho);
                return RotarIzquierda(nodo);
            }

            return nodo;
        }
        private int ObtenerAltura(Nodo nodo)
        {
            if (nodo == null)
                return 0;

            return nodo.Altura;
        }
        private void ActualizarAltura(Nodo nodo)
        {
            nodo.Altura = 1 + Math.Max(ObtenerAltura(nodo.Izquierdo),ObtenerAltura(nodo.Derecho));
        }
        private int ObtenerBalance(Nodo nodo)
        {
            return ObtenerAltura(nodo.Izquierdo) - ObtenerAltura(nodo.Derecho);
        }
        private Nodo RotarDerecha(Nodo nodo)
        {
            Nodo nuevaRaiz = nodo.Izquierdo;
            Nodo temporal = nuevaRaiz.Derecho;

            nuevaRaiz.Derecho = nodo;
            nodo.Izquierdo = temporal;

            ActualizarAltura(nodo);
            ActualizarAltura(nuevaRaiz);

            return nuevaRaiz;
        }
        private Nodo RotarIzquierda(Nodo nodo)
        {
            Nodo nuevaRaiz = nodo.Derecho;
            Nodo temporal = nuevaRaiz.Izquierdo;

            nuevaRaiz.Izquierdo = nodo;
            nodo.Derecho = temporal;

            ActualizarAltura(nodo);
            ActualizarAltura(nuevaRaiz);

            return nuevaRaiz;
        }
        public Transferencia Buscar(int codigo)
        {
            Nodo actual = raiz;

            while (actual != null)
            {
                if (codigo == actual.Dato.Codigo)
                {
                    return actual.Dato;
                }

                if (codigo < actual.Dato.Codigo)
                {
                    actual = actual.Izquierdo;
                }
                else
                {
                    actual = actual.Derecho;
                }
            }

            return null;
        }
        public List<Transferencia> ObtenerHistorial()
        {
            List<Transferencia> historial =
                new List<Transferencia>();

            RecorrerEnOrden(raiz, historial);

            return historial;
        }
        private void RecorrerEnOrden(
            Nodo nodo, List<Transferencia> historial)
        {
            if (nodo == null)
            {
                return;
            }

            RecorrerEnOrden(nodo.Izquierdo, historial);

            historial.Add(nodo.Dato);

            RecorrerEnOrden(nodo.Derecho, historial);
        }
    }
}

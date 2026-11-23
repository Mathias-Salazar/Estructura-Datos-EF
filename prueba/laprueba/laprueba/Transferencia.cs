using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laprueba
{
    internal class Transferencia
    {
        public int Codigo { get; set; }
        public string Remitente { get; set; }
        public string Destinatario { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public Transferencia(int codigo, string remitente,string destinatario, decimal monto)
        {
            Codigo = codigo;
            Remitente = remitente;
            Destinatario = destinatario;
            Monto = monto;
            Fecha = DateTime.Now;
        }
        public override string ToString()
        {
            return $"Código: {Codigo}\n" +
                   $"Remitente: {Remitente}\n" +
                   $"Destinatario: {Destinatario}\n" +
                   $"Monto: S/ {Monto:F2}\n" +
                   $"Fecha: {Fecha:dd/MM/yyyy HH:mm}";
        }
    }
}

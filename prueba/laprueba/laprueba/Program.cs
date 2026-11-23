using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laprueba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArbolBinario arbol = new ArbolBinario();

            int siguienteCodigo = 1001;

            int opcion;

            do
            {
                Console.WriteLine();
                Console.WriteLine("================================");
                Console.WriteLine("       BILLETERA MOVIL");
                Console.WriteLine("================================");
                Console.WriteLine("1. Registrar transferencia");
                Console.WriteLine("2. Buscar transferencia");
                Console.WriteLine("3. Mostrar historial");
                Console.WriteLine("4. Salir");
                Console.WriteLine("================================");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida.");
                    opcion = 0;
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("REGISTRAR TRANSFERENCIA");

                        string remitente =
                            LeerNombre("Ingrese remitente: ");

                        string destinatario =
                            LeerNombre("Ingrese destinatario: ");

                        decimal monto = LeerMonto();

                        Transferencia nueva =
                            new Transferencia(
                                siguienteCodigo,
                                remitente,
                                destinatario,
                                monto
                            );

                        arbol.InsertarTransferencia(nueva);

                        siguienteCodigo++;

                        Console.WriteLine();
                        Console.WriteLine("Transferencia registrada correctamente.");
                        Console.WriteLine(nueva);
                        break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("BUSCAR TRANSFERENCIA");
                        Console.Write("Ingrese código: ");

                        if (!int.TryParse(Console.ReadLine(), out int codigo))
                        {
                            Console.WriteLine("Código inválido.");
                            break;
                        }

                        Transferencia encontrada = arbol.Buscar(codigo);

                        if (encontrada != null)
                        {
                            Console.WriteLine("Transferencia encontrada:");
                            Console.WriteLine(encontrada);
                        }
                        else
                        {
                            Console.WriteLine("No existe esa transferencia.");
                        }
                        break;

                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("HISTORIAL DE TRANSFERENCIAS");

                        var historial = arbol.ObtenerHistorial();

                        if (historial.Count == 0)
                        {
                            Console.WriteLine("No hay transferencias registradas.");
                        }
                        else
                        {
                            foreach (Transferencia t in historial)
                            {
                                Console.WriteLine("--------------------------");
                                Console.WriteLine(t);
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Gracias por utilizar la billetera móvil.");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 4);

        }
        static string LeerNombre(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);

                string nombre = Console.ReadLine() ?? "";
                nombre = nombre.Trim();

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    return nombre;
                }

                Console.WriteLine("El nombre no puede estar vacío.");
            }
        }
        static decimal LeerMonto()
        {
            while (true)
            {
                Console.Write("Ingrese monto (S/): ");

                if (decimal.TryParse(Console.ReadLine(), out decimal monto) && monto > 0)
                {
                    return monto;
                }

                Console.WriteLine("Ingrese un monto válido mayor a cero.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora
{
    class Program
    {
        static void Main(string[] args)
        {
            Expendedora expendedora1 = new Expendedora();
            bool mostrarMenu = true;
            while (mostrarMenu)
            {
                mostrarMenu = menuUsuario(expendedora1);
            }
        }
        static bool menuUsuario(Expendedora expendedora)
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1. Encender máquina");
            if (expendedora.encendida)
            {
                Console.WriteLine("2. Ver listado de latas disponibles");
                Console.WriteLine("3. Insertar lata");
                Console.WriteLine("4. Comprar lata");
                Console.WriteLine("5. Ver balance de máquina");
                Console.WriteLine("6. Ver stock y detalle por lata");
                Console.WriteLine("Ingrese el número de operación:");
            }

            switch (Console.ReadLine())
            {
                case "1":
                    expendedora.encenderMaquina();
                    return true;
                case "2":
                    Console.WriteLine(expendedora.mostrarLatasDisponibles());
                    return true;
                case "3":
                    Console.WriteLine(expendedora.mostrarLatasDisponibles());
                    Console.WriteLine("Ingrese código de lata a insertar");
                    string codigoLataAIngresar = Console.ReadLine();
                    if (expendedora.existeCodigoLata(codigoLataAIngresar))
                    {
                        Lata lataAIngresar = new Lata();
                        lataAIngresar.codigo = codigoLataAIngresar;
                        Console.Clear();
                        Console.WriteLine("Ingrese el precio de venta");
                        string precioLataAIngresar = Console.ReadLine();
                        if (Convert.ToDouble(precioLataAIngresar) > 0) {
                            lataAIngresar.precio = Convert.ToDouble(precioLataAIngresar);
                            Console.Clear();
                            Console.WriteLine("Ingrese el volumen de lata");
                            string volumenLataAIngresar = Console.ReadLine();
                            if (Convert.ToDouble(volumenLataAIngresar) > 0) {
                                lataAIngresar.volumen = Convert.ToDouble(volumenLataAIngresar);
                            }
                        }
                        return true;
                    }
                    return true;
                default:
                    return true;
            }
        }
        static void ingresarLata(Expendedora expendedora) { 
            
        }
        static void extraerLata(Expendedora expendedora) { }
        static void obtenerBalance(Expendedora expendedora) { }
        static void mostrarStock(Expendedora expendedora) { }
    }
}

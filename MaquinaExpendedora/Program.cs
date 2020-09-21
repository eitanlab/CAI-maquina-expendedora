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
            if (expendedora.encendida)
            {
                Console.WriteLine("MENU MAQUINA ENCENDIDA");
                Console.WriteLine("2. Ver listado de latas disponibles");
                Console.WriteLine("3. Insertar lata");
                Console.WriteLine("4. Comprar lata");
                Console.WriteLine("5. Ver balance de máquina");
                Console.WriteLine("6. Ver stock y detalle por lata");
                Console.WriteLine("Ingrese el número de operación:");
            } else
            {
                Console.WriteLine("MENU MAQUINA APAGADA");
                Console.WriteLine("1. Encender máquina");
            }

            switch (Console.ReadLine())
            {
                case "1":
                    expendedora.encenderMaquina();
                    return true;
                case "2":
                    Console.WriteLine(latasPosibles());
                    return true;
                case "3":
                    ingresarLata(expendedora);
                    return true;
                default:
                    return true;
            }
        }
        static void ingresarLata(Expendedora expendedora) {
            Console.Clear();
            Console.WriteLine("Códigos de latas disponibles");
            Console.WriteLine(latasPosibles());
            Console.WriteLine("Ingrese código de lata a insertar");
            string codigoLataAIngresar = Console.ReadLine();
            try
            {
                Lata lataAIngresar = new Lata(codigoLataAIngresar);
                Console.WriteLine("Ingrese el precio de venta");
                    string precioLataAIngresar = Console.ReadLine();
                    if (Convert.ToDouble(precioLataAIngresar) > 0)
                    {
                        lataAIngresar.precio = Convert.ToDouble(precioLataAIngresar);
                        Console.WriteLine("Ingrese el volumen de lata");
                        string volumenLataAIngresar = Console.ReadLine();
                        if (Convert.ToDouble(volumenLataAIngresar) > 0)
                        {
                            lataAIngresar.volumen = Convert.ToDouble(volumenLataAIngresar);
                            expendedora.agregarLata(lataAIngresar);
                        }
                    }
            }
            catch
            {

            }
        }
        static void extraerLata(Expendedora expendedora) { }
        static void obtenerBalance(Expendedora expendedora) { }
        static void mostrarStock(Expendedora expendedora) { }

        static string latasPosibles ()
        {
            string strLatasPosibles =
                "@CO1 - Coca Cola Regular" +
                "@CO2 - Coca Cola Zero" +
                "@SP1 - Sprite Regular" +
                "@SP2 - Sprite Zero" +
                "@FA1 - Fanta Regular" +
                "@FA2 - Fanta Zero";
            strLatasPosibles = strLatasPosibles.Replace("@", System.Environment.NewLine);
            return strLatasPosibles;
        }
    }
}

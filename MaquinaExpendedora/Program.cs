using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

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
            Console.WriteLine();
            Console.WriteLine("[MENU]");
            Console.WriteLine("1. Encender máquina");
            Console.WriteLine("2. Ver listado de latas disponibles");
            Console.WriteLine("3. Insertar lata");
            Console.WriteLine("4. Comprar lata");
            Console.WriteLine("5. Ver balance de máquina");
            Console.WriteLine("6. Ver stock y detalle por lata");
            Console.WriteLine();
            Console.WriteLine("Ingrese el número de operación:");
            string opcionElegida = Console.ReadLine();
            if (expendedora.encendida)
            {
                switch (opcionElegida)
                {
                    case "1":
                        Console.WriteLine("La expendedora ya está encendida");
                        return true;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("[Códigos de latas disponibles]");
                        Console.WriteLine(latasPosibles());
                        return true;
                    case "3":
                        ingresarLata(expendedora);
                        return true;
                    default:
                        Console.Clear();
                        Console.WriteLine("El código ingresado no corresponde a una opción válida");
                        return true;
                }
            }
            else 
            {
                if (opcionElegida == "1") { 
                    expendedora.encenderMaquina();
                    Console.WriteLine("Expendedora encendida");
                    return true;
                } else
                {
                    Console.Clear();
                    Console.WriteLine("Debe encender la expendedora para poder operar");
                }
                return true;
            }
        }
        static void ingresarLata(Expendedora expendedora) {
            if(expendedora.encendida)
            {
                Console.Clear();
                Console.WriteLine("[Códigos de latas disponibles]");
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
                        } else
                        {
                            Console.WriteLine("El volumen ingresado es inválido");
                        }
                    } else
                    {
                        Console.WriteLine("El precio ingresado es inválido");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } else
            {
                Console.WriteLine("La expendedora está apagada, por favor enciéndala para realizar la operación");
            }
            
        }
        static void extraerLata(Expendedora expendedora) { }
        static void obtenerBalance(Expendedora expendedora) { }
        static void mostrarStock(Expendedora expendedora) { }

        static string latasPosibles ()
        {
            string strLatasPosibles =
                "CO1 - Coca Cola Regular" +
                "@CO2 - Coca Cola Zero" +
                "@SP1 - Sprite Regular" +
                "@SP2 - Sprite Zero" +
                "@FA1 - Fanta Regular" +
                "@FA2 - Fanta Zero@";
            strLatasPosibles = strLatasPosibles.Replace("@", System.Environment.NewLine);
            return strLatasPosibles;
        }
    }
}

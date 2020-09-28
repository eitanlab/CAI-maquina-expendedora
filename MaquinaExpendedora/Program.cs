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
            Expendedora expendedora1 = new Expendedora(3);
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
                        Console.Clear();
                        Console.WriteLine("La expendedora ya está encendida");
                        return true;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(latasPosibles());
                        return true;
                    case "3":
                        Console.Clear();
                        ingresarLata(expendedora);
                        return true;
                    case "4":
                        Console.Clear();
                        extraerLata(expendedora);
                        return true;
                    case "5":
                        Console.Clear();
                        obtenerBalance(expendedora);
                        return true;
                    case "6":
                        Console.Clear();
                        mostrarStock(expendedora);
                        return true;
                    default:
                        Console.Clear();
                        Console.WriteLine("El código ingresado no corresponde a una opción válida, intente nuevamente");
                        return true;
                }
            }
            else 
            {
                if (opcionElegida == "1") {
                    Console.Clear();
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
                            try
                            {
                                expendedora.agregarLata(lataAIngresar);
                                Console.Clear();
                                Console.WriteLine("Lata " + lataAIngresar.toString() + " fue agregada a la expendedora");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        } else
                        {
                            Console.Clear();
                            Console.WriteLine("El volumen ingresado es inválido");
                        }
                    } else
                    {
                        Console.Clear();
                        Console.WriteLine("El precio ingresado es inválido");
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            } else
            {
                Console.Clear();
                Console.WriteLine("La expendedora está apagada, por favor enciéndala para realizar la operación");
            }
            
        }
        static void extraerLata(Expendedora expendedora) {
            if (expendedora.encendida)
            {
                if(expendedora.latas.Count > 0)
                {
                    Console.Clear();
                    Console.WriteLine(latasPosibles());
                    Console.WriteLine("Ingrese código de lata a comprar");
                    string codigoLataAExtraer = Console.ReadLine();
                    try
                    {
                        Lata lataEncontrada = expendedora.latas.Find(lata => lata.codigo == codigoLataAExtraer);
                        if (lataEncontrada != null)
                        {
                            Console.WriteLine("Ingrese el dinero");
                            string dinero = Console.ReadLine();
                            if (lataEncontrada.precio <= Convert.ToDouble(dinero))
                            {
                                Lata lataExtraida = expendedora.extraerLata(lataEncontrada);
                                Console.Clear();
                                Console.WriteLine("Lata extraida: " + lataExtraida.toString());
                            }
                            else
                            {
                                throw new DineroInsuficienteException();
                            }
                        }
                        else
                        {
                            throw new CodigoInvalidoException();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } else
                {
                    Console.Clear();
                    Console.WriteLine("La expendedora está vacía");
                }
            }
            else
            {
                Console.WriteLine("La expendedora está apagada, por favor enciéndala para realizar la operación");
            }
        }
        static void obtenerBalance(Expendedora expendedora) {
            string balance = expendedora.getBalance();
            Console.WriteLine(balance);
        }
        static void mostrarStock(Expendedora expendedora) { 
            if (expendedora.latas.Count > 0)
            {
                foreach(Lata lata in expendedora.latas)
                {
                    Console.WriteLine(lata.marca + " - $" + lata.precio + " / $/L " + lata.getPrecioPorLitro());
                }
            }
            else
            {
                Console.WriteLine("La expendedora está vacía");
            }
        }

        static string latasPosibles ()
        {
            string strLatasPosibles =
                "[Códigos de latas disponibles]" +
                "@CO1 - Coca Cola Regular" +
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

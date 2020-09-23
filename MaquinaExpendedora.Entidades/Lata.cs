using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora.Entidades
{
    public class Lata
    {
        string _codigo;
        string _marca;
        string _sabor;
        double _precio;
        double _volumen;

        public Lata() { }
        public Lata(string codigoLata)
        {
            codigo = codigoLata;
            switch (codigo)
            {
                case "CO1":
                    marca = "Coca Cola";
                    sabor = "Regular";
                    return;
                case "CO2":
                    marca = "Coca Cola";
                    sabor = "Zero";
                    return;
                case "SP1":
                    marca = "Sprite";
                    sabor = "Regular";
                    return;
                case "SP2":
                    marca = "Sprite";
                    sabor = "Zero";
                    return;
                case "FA1":
                    marca = "fanta";
                    sabor = "Regular";
                    return;
                case "FA2":
                    marca = "Fanta";
                    sabor = "Zero";
                    return;
                default:
                    //throw new System.ArgumentException("El código ingresado es inválido", "original");
                    return;
            }
        }
        public string codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;
            }
        }
        public string marca
        {
            get
            {
                return _marca;
            }
            set
            {
                _marca = value;
            }
        }
        public string sabor
        {
            get
            {
                return _sabor;
            }
            set
            {
                _sabor = value;
            }
        }
        public double precio
        {
            get
            {
                return _precio;
            }
            set
            {
                _precio = value;
            }
        }
        public double volumen
        {
            get
            {
                return _volumen;
            }
            set
            {
                _volumen = value;
            }
        }
        public double getPrecioPorLitro()
        {
            double precioPorLitro = precio * 1000 / volumen;
            return precioPorLitro;
        }
        public string toString()
        {
            return codigo + " - " + marca + " " + sabor;
        }
    }
}

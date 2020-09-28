using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Expendedora
    {
        List<Lata> _latas;
        string _proveedor;
        int _capacidad;
        double _dinero;
        bool _encendida;
        public Expendedora(int capacidadIngresada)
        {
            latas = new List<Lata>();
            capacidad = capacidadIngresada;
            dinero = 0;
        }

        public List<Lata> latas
        {
            get
            {
                return _latas;
            }
            set
            {
                _latas = value;
            }
        }
        public string proveedor
        {
            get
            {
                return _proveedor;
            }
            set
            {
                _proveedor = value;
            }
        }
        public int capacidad
        {
            get
            {
                return _capacidad;
            }
            set
            {
                _capacidad = value;
            }
        }
        public double dinero
        {
            get
            {
                return _dinero;
            }
            set
            {
                _dinero = value;
            }
        }
        public bool encendida
        {
            get
            {
                return _encendida;
            }
            set
            {
                _encendida = value;
            }
        }
        public void agregarLata(Lata lata)
        {
            if (latas.Count < capacidad)
            {
                latas.Add(lata);
            } else
            {
                throw new CapacidadInsuficienteException();
            }
        }
        public Lata extraerLata(Lata lataAExtraer)
        {
            latas.Remove(lataAExtraer);
            dinero += lataAExtraer.precio;
            return lataAExtraer;
        }
        public string getBalance()
        {
            string balance = "La expendedora tiene $" + dinero + " y quedan " + latas.Count() + " latas en stock";
            return balance;
        }
        public void encenderMaquina()
        {
            if (encendida) throw new Exception();
            encendida = true;
        }
        public bool estaVacia()
        {
            return false;
        }

        public string mostrarLatasDisponibles()
        {
            string strListadoDeLatas = "";
            foreach (Lata lata in latas)
            {
                strListadoDeLatas += Environment.NewLine + lata.toString();
            }
            return strListadoDeLatas;
        }

        public bool existeCodigoLata(string codigo)
        {
            bool existeCodigo = false;
            foreach (Lata lata in latas)
            {
                if (lata.codigo == codigo) existeCodigo = true;
            }
            return existeCodigo;
        }
    }
}

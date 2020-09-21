using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora
{
    public class Expendedora
    {
        List<Lata> _latas;
        string _proveedor;
        int _capacidad;
        double _dinero;
        bool _encendida;
        public Expendedora()
        {
            List<Lata> lasLatas = new List<Lata>();
            lasLatas.Add(new Lata("CO1"));
            lasLatas.Add(new Lata("CO2"));
            lasLatas.Add(new Lata("SP1"));
            lasLatas.Add(new Lata("SP2"));
            lasLatas.Add(new Lata("FA1"));
            lasLatas.Add(new Lata("FA2"));
            latas = lasLatas;
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
        public void agregarLata(Lata codigo)
        {

        }
        public Lata extraerLata(string a,double b)
        {
            return null;
        }
        public string getBalance() {
            return "";
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
            foreach(Lata lata in latas)
            {
                if (lata.codigo == codigo) existeCodigo = true;
            }
            return existeCodigo;
        }

    }
}

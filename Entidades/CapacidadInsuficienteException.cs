using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class CapacidadInsuficienteException : Exception
    {
        public CapacidadInsuficienteException() : base("La máquina está llena, no se pueden agregar más latas") { }
    }
}

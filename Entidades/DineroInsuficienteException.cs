using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DineroInsuficienteException : Exception
    {
        public DineroInsuficienteException() : base("El dinero ingresado es insuficiente") {}
    }
}

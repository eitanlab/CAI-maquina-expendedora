using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CodigoInvalidoException : Exception
    {
        public CodigoInvalidoException() : base("El código ingresado es inválido") { } 
    }
}

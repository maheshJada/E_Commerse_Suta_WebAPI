using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SutaWebAPI_Common.Exceptions
{
    public class SutaException : Exception
    {
        public SutaException()
        {

        }

        public SutaException(string message) : base(message)
        {

        }

        public SutaException(string message, Exception innerEx) : base(message, innerEx)
        {

        }
    }
}

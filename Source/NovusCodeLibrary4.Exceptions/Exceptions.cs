using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovusCodeLibrary.Exceptions
{
    public class RaiseException : ApplicationException
    {
        public RaiseException(string Message,
                  Exception innerException)
            : base(Message, innerException) { }
        public RaiseException(string Message) : base(Message) { }
        public RaiseException() { }
             


    }
}

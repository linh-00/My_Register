using Inc.MyRegister.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Shared.Exceptions.Exceptions
{
    internal class IntegracaoUAUException : BaseException
    {
        public IntegracaoUAUException(ErrorMessage error)
            : base(error)
        {
        }
        public IntegracaoUAUException(ErrorMessage error, Exception innerException)
            : base(error, innerException)
        {
        }
        public IntegracaoUAUException(IEnumerable<ErrorMessage> errors, Exception innerException)
            : base(errors, innerException)
        {
        }
        public IntegracaoUAUException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

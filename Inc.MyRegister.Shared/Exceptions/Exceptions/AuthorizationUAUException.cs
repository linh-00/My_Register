using Inc.MyRegister.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Shared.Exceptions.Exceptions
{
    internal class AuthorizationUAUException : BaseException
    {
        public AuthorizationUAUException(ErrorMessage error)
            : base(error)
        {
        }

        public AuthorizationUAUException(ErrorMessage error, Exception innerEception)
            : base(error, innerEception)
        {
        }
        public AuthorizationUAUException(IEnumerable<ErrorMessage> errors, Exception innerException)
            : base(errors, innerException)
        {
        }
        public AuthorizationUAUException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

    }
}

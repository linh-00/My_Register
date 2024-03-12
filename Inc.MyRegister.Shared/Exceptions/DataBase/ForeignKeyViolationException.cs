using Inc.MyRegister.Shared.Exceptions.Exceptions;
using Inc.MyRegister.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Shared.Exceptions.DataBase
{
    [Serializable]
    public class ForeignKeyViolationException : BaseException
    {
        public ForeignKeyViolationException(ErrorMessage error)
           : base(error)
        {
        }

        public ForeignKeyViolationException(ErrorMessage error, Exception innerException)
            : base(error, innerException)
        {
        }

        public ForeignKeyViolationException(IEnumerable<ErrorMessage> errors, Exception innerException)
            : base(errors, innerException)
        {
        }

        public ForeignKeyViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

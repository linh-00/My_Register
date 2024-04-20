using Inc.MyRegister.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Shared.Exceptions.Exceptions
{
    public class BaseException : Exception
    {
        public IEnumerable<ErrorMessage> Errors { get; private set; }

        protected BaseException(string code, string message)
            : this(new ErrorMessage(code, message))
        {
        }

        protected BaseException(string code, string message, Exception innerException)
            : this(new ErrorMessage(code, message), innerException)
        {
        }

        protected BaseException(ErrorMessage error)
            : this(new ErrorMessage[] { error })
        {
        }

        protected BaseException(ErrorMessage error, Exception innerException)
            : this(new ErrorMessage[] { error }, innerException)
        {
        }

        protected BaseException(IEnumerable<ErrorMessage> errors)
            : base(string.Join("\n", errors?.Select(error => error.Message)))
        {
            Errors = errors;
        }

        protected BaseException(IEnumerable<ErrorMessage> errors, Exception innerException)
            : base(string.Join("\n", errors?.Select(error => error.Message)), innerException)
        {
            Errors = errors;
        }

        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Shared.Enums
{
    public enum UseCaseResponseKind
    {
        Success,
        DataPersisted,
        DataAccepted,
        InternalServerError,
        RequestValidationError,
        ForeingKeyViolationError,
        UniqueViolationError,
        RequiredResourceNotFound,
        NotFound,
        Unauthorized,
        Forbidden,
        Unavailable
    }
}

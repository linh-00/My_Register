using Inc.MyRegister.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inc.MyRegister.Interfaces
{
    public interface IActionResultConverter
    {
        IActionResult Convert<T>(UseCaseResponse<T> response, bool noContentIfSuccess = false);
    }
}

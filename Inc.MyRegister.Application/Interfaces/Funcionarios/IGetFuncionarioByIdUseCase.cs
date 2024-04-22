using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Shared.Interface;

namespace Inc.MyRegister.Application.Interfaces.Funcionarios
{
    public interface IGetFuncionarioByIdUseCase : IUseCase<int, FuncionarioDTO>
    {
    }
}

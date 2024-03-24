using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Shared.Interface;

namespace Inc.MyRegister.Application.Interfaces.Empresas
{
    public interface IListEmpresaUseCase : IUseCaseOnlyReponse<List<EmpresaDTO>>
    {
    }
}

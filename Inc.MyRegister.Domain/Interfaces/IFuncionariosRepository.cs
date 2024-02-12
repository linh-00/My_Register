using Inc.MyRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Domain.Interfaces
{
    public interface IFuncionariosRepository
    {
        Task<Funcionarios> InsertFuncionariosAsync(Funcionarios Request);
        Task<IEnumerable<Funcionarios>> GetAllFuncionariosAsync();
        Task<Funcionarios> GetFuncionariosByIdAsync(int id);
        Task<IEnumerable<Funcionarios>> GetFuncionariosByEmpresaIdAsync(int EmpresaId);
    }
}

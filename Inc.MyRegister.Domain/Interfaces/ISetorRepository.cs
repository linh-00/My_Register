using Inc.MyRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Domain.Interfaces
{
    public interface ISetorRepository
    {
        Task<Setores> InsertSetoresAsync(Setores Request);
        Task<IEnumerable<Setores>> GetAllSetoresAsync();
        Task<Setores> GetSetoresByIdAsync(int Id);
        Task<IEnumerable<Setores>> GetSetorByEmpresaAsync(int EmpresaId);
        Task<IEnumerable<Setores>> GetSetorByFuncionarioAsync(int FuncionarioId);
        Task<IEnumerable<Setores>> GetSetorByUsuarioAsync(int UsuarioId);


    }
}

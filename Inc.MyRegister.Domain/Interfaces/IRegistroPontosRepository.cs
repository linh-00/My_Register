using Inc.MyRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Domain.Interfaces
{
    public interface IRegistroPontosRepository
    {
        Task<RegistroPontos> InsertRegistroPontoRepositoryAsync(RegistroPontos Request);
        Task<IEnumerable<RegistroPontos>> GetAllRegistroPontosAsync();
        Task<RegistroPontos> GetRegistroPontosByIdAsync(int Id);
        Task<IEnumerable<RegistroPontos>> GetRegistroPontoByFuncionarioAsync(int FuncionarioId);
    }
}

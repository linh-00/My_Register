using Inc.MyRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Domain.Interfaces
{
    public interface IEmpresasRepository
    {
        Task<Empresas> InsertEmpresaAsync(Empresas Request);
        Task<IEnumerable<Empresas>> GetEmpresasAsync();
        Task<Empresas> GetEmpresasByIdAsync(int Id);
        Task<Empresas> UpdateEmpresasAsync(Empresas Request);
    }
}

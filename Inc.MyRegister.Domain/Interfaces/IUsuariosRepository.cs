using Inc.MyRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Domain.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<Usuarios> InsertUsuariosAsync(Usuarios Request);
        Task<IEnumerable<Usuarios>> GetAllUsuariosAsync();
        Task<Usuarios> GetUsuariosByIdAsync(int Id);
        Task<Usuarios> UpdateUsuariosAsync(Usuarios Request);
    }
}

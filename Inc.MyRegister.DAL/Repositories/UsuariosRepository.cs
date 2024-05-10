using Inc.MyRegister.DAL.Contexts;
using Inc.MyRegister.DAL.Models;
using Inc.MyRegister.Domain.Entities;
using Inc.MyRegister.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inc.MyRegister.DAL.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private MyRegisterContext dbMyRegister;
        public UsuariosRepository(MyRegisterContext dbMyRegister)
        {
            this.dbMyRegister = dbMyRegister;
        }
        public async Task<Usuarios> InsertUsuariosAsync(Usuarios Request)
        {
            USUARIO newUsuarios = new USUARIO()
            {
                DS_NOME = Request.Nome,
                TP_CARGO = Request.Cargo,
                DS_EMAIL = Request.Email,
                DS_SENHA = Request.Senha,
            };

            dbMyRegister.USUARIOs.Add(newUsuarios);
            await dbMyRegister.SaveChangesAsync();
            Request.SetId(newUsuarios.ID_USUARIO);
            return Request;
        }

        public async Task<IEnumerable<Usuarios>> GetAllUsuariosAsync()
        {
            List<USUARIO> entity = await dbMyRegister.USUARIOs.ToListAsync();

            return entity.Select(res =>
            {
                return new Usuarios(res.DS_NOME, res.TP_CARGO, res.DS_EMAIL, res.DS_SENHA);
            });

        }
        public async Task<Usuarios> GetUsuariosByIdAsync(int Id)
        {
            var entity = await dbMyRegister.USUARIOs.Where(x => x.ID_USUARIO == Id).FirstAsync();

            if (entity is not null)
                return new Usuarios(entity.DS_NOME, entity.TP_CARGO, entity.DS_EMAIL, entity.DS_SENHA);
            else
                throw new Exception("Usuário não encontrado");
        }
        public async Task<Usuarios> UpdateUsuariosAsync(Usuarios Request)
        {
            var entity = await dbMyRegister.USUARIOs.Where(x => x.ID_USUARIO == Request.Id).FirstAsync();
            if (entity is not null)
            {
                entity.DS_NOME = Request.Nome;
                entity.TP_CARGO = Request.Cargo;
                entity.DS_EMAIL = Request.Email;
                entity.DS_SENHA = Request.Senha;

                await dbMyRegister.SaveChangesAsync();
                return Request;
            }

            else
                throw new Exception("Usuário não adicionado");
        }

    }
}

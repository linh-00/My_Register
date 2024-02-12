using Azure.Core;
using Inc.MyRegister.DAL.Context;
using Inc.MyRegister.Domain.Interfaces;
using Inc.MyRegister.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inc.MyRegister.Domain.Entities;

namespace Inc.MyRegister.DAL.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private dbMyRegisterContext dbMyRegister;
        public UsuariosRepository(dbMyRegisterContext dbMyRegister)
        {
            this.dbMyRegister = dbMyRegister;
        }
        public async Task<Usuarios> InsertUsuariosAsync(Usuarios Request)
        {
            Usuario newUsuarios = new Usuario()
            {
                Nome = Request.Nome,
                Cargo = Request.Cargo,
                Email = Request.Email,
                Senha = Request.Senha,
            };

            dbMyRegister.Usuarios.Add(newUsuarios);
            await dbMyRegister.SaveChangesAsync();
            Request.SetId(newUsuarios.Id);
            return Request;
        }

        public async Task<IEnumerable<Usuarios>> GetUsuariosAsync()
        {
            List<Usuario> entity  = await dbMyRegister.Usuarios.ToListAsync();

            return entity.Select(res => 
            {
                return new Usuarios(res.Nome, res.Cargo, res.Email, res.Senha);
            });           

        }
        public async Task<Usuarios> GetUsuariosByIdAsync(int Id)
        {
            var entity = await dbMyRegister.Usuarios.Where(x=> x.Id == Id ).FirstAsync();

            if (entity is not null)
                return new Usuarios(entity.Nome, entity.Cargo, entity.Email, entity.Senha);
            else
                throw new Exception("Usuário não encontrado");
        }
        public async Task<Usuarios> UpdateUsuariosAsync(Usuarios Request)
        {
            var entity = await dbMyRegister.Usuarios.Where(x => x.Id == Request.Id).FirstAsync();
            if (entity is not null)
            {
                entity.Nome = Request.Nome;
                entity.Cargo = Request.Cargo;
                entity.Email = Request.Email;
                entity.Senha = Request.Senha;

                await dbMyRegister.SaveChangesAsync();
                return Request;
            }

            else
                throw new Exception("Usuário não adicionado");
        }
               
    }
}

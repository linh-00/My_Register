using Inc.MyRegister.DAL.Context;
using Inc.MyRegister.DAL.Models;
using Inc.MyRegister.Domain.Entities;
using Inc.MyRegister.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.DAL.Repositories
{
    public class SetoresRepository : ISetorRepository
    {
        private dbMyRegisterContext dbMyRegister;
        public SetoresRepository(dbMyRegisterContext dbMyRegister)
        {
            this.dbMyRegister = dbMyRegister;
        }

        public async Task<Setores> InsertSetoresAsync(Setores Request)
        {
            Setor newSetores = new Setor()
            {
                Nome = Request.Nome,
                FL_Status = Request.FL_Status,
            };
            dbMyRegister.Setores.Add(newSetores);
            await dbMyRegister.SaveChangesAsync();
            Request.SetId(newSetores.Id);
            return Request;
        }
        public async Task<IEnumerable<Setores>> GetAllSetoresAsync()
        {
            List<Setor> entity = await dbMyRegister.Setores
                .Include(x => x.IdUsuariosNavigation)
                .Include(x => x.IdFuncionariosNavigation)
                .Include(x => x.IdEmpresaNavigation)
                .ToListAsync();
            return entity.Select(res =>
            {
                var Usuarios = res.IdUsuariosNavigation;
                var UsuariosEntity = new Usuarios(Usuarios.Id, Usuarios.Nome, Usuarios.Cargo, Usuarios.Email, Usuarios.Senha);

                var Empresa = res.IdEmpresaNavigation;
                var EmpresaEntity = new Empresas(Empresa.Id, Empresa.Nome, Empresa.CNPJ, Empresa.Dominio, Empresa.Contato, Empresa.Email, Empresa.Endereco);

                var Funcionario = res.IdFuncionariosNavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.Id, Funcionario.Nome, Funcionario.Contato, Funcionario.Email, Funcionario.Matricula, Funcionario.CPF, Funcionario.Setor, Funcionario.Cargo, EmpresaEntity);

                return new Setores(res.Id, res.Nome, res.FL_Status, FuncionarioEntity, UsuariosEntity, EmpresaEntity);
            });

        }
        public async Task<Setores> GetSetoresByIdAsync(int Id)
        {
            var entity = await dbMyRegister.Setores
              .Where(x => x.Id == Id)
              .Include(x => x.IdEmpresaNavigation)
              .Include(x => x.IdFuncionariosNavigation)
              .Include(x => x.IdUsuariosNavigation)
              .FirstAsync();
            if (entity is not null)
            {
                var Usuarios = entity.IdUsuariosNavigation;
                var UsuariosEntity = new Usuarios(Usuarios.Id, Usuarios.Nome, Usuarios.Cargo, Usuarios.Email, Usuarios.Senha);

                var Empresa = entity.IdEmpresaNavigation;
                var EmpresaEntity = new Empresas(Empresa.Id, Empresa.Nome, Empresa.CNPJ, Empresa.Dominio, Empresa.Contato, Empresa.Email, Empresa.Endereco);

                var Funcionario = entity.IdFuncionariosNavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.Id, Funcionario.Nome, Funcionario.Contato, Funcionario.Email, Funcionario.Matricula, Funcionario.CPF, Funcionario.Setor, Funcionario.Cargo, EmpresaEntity);

                return new Setores(entity.Id, entity.Nome, entity.FL_Status, FuncionarioEntity, UsuariosEntity, EmpresaEntity);
            }
            else
                throw new Exception("Setor não encontrado");
        }
        public async Task<IEnumerable<Setores>> GetSetorByEmpresaAsync(int EmpresaId)
        {
            List<Setor> entity = await dbMyRegister
                .Setores
                .Include(x => x.IdEmpresaNavigation)
                .Include(x => x.IdFuncionariosNavigation)
                .Include(x => x.IdUsuariosNavigation)
                .Where(x => x.Id == EmpresaId)
                .ToListAsync();

            return entity.Select(res =>
            {
                var Empresa = res.IdEmpresaNavigation;
                var EmpresaEntity = new Empresas(Empresa.Id, Empresa.Nome, Empresa.CNPJ, Empresa.Dominio, Empresa.Contato, Empresa.Email, Empresa.Endereco);

                var Funcionario = res.IdFuncionariosNavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.Id, Funcionario.Nome, Funcionario.Contato, Funcionario.Email, Funcionario.Matricula, Funcionario.CPF, Funcionario.Setor, Funcionario.Cargo, EmpresaEntity);

                var Usuario = res.IdUsuariosNavigation;
                var UsuarioEntity = new Usuarios(Usuario.Id, Usuario.Nome, Usuario.Cargo, Usuario.Email, Usuario.Senha);

                return new Setores(res.Id, res.Nome, res.FL_Status, FuncionarioEntity, UsuarioEntity, EmpresaEntity);
            });
        }
        public async Task<IEnumerable<Setores>> GetSetorByFuncionarioAsync(int FuncionarioId)
        {
            List<Setor> entity = await dbMyRegister
                .Setores
                .Include(x => x.IdEmpresaNavigation)
                .Include(x => x.IdFuncionariosNavigation)
                .Include(x => x.IdUsuariosNavigation)
                .Where(x => x.Id == FuncionarioId)
                .ToListAsync();

            return entity.Select(res =>
            {
                var Empresa = res.IdEmpresaNavigation;
                var EmpresaEntity = new Empresas(Empresa.Id, Empresa.Nome, Empresa.CNPJ, Empresa.Dominio, Empresa.Contato, Empresa.Email, Empresa.Endereco);

                var Funcionario = res.IdFuncionariosNavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.Id, Funcionario.Nome, Funcionario.Contato, Funcionario.Email, Funcionario.Matricula, Funcionario.CPF, Funcionario.Setor, Funcionario.Cargo, EmpresaEntity);

                var Usuario = res.IdUsuariosNavigation;
                var UsuarioEntity = new Usuarios(Usuario.Id, Usuario.Nome, Usuario.Cargo, Usuario.Email, Usuario.Senha);

                return new Setores(res.Id, res.Nome, res.FL_Status, FuncionarioEntity, UsuarioEntity, EmpresaEntity);
            });
        }
        public async Task<IEnumerable<Setores>> GetSetorByUsuarioAsync(int UsuarioId)
        {
            List<Setor> entity = await dbMyRegister
                .Setores
                .Include(x => x.IdEmpresaNavigation)
                .Include(x => x.IdFuncionariosNavigation)
                .Include(x => x.IdUsuariosNavigation)
                .Where(x => x.Id == UsuarioId)
                .ToListAsync();

            return entity.Select(res =>
            {
                var Empresa = res.IdEmpresaNavigation;
                var EmpresaEntity = new Empresas(Empresa.Id, Empresa.Nome, Empresa.CNPJ, Empresa.Dominio, Empresa.Contato, Empresa.Email, Empresa.Endereco);

                var Funcionario = res.IdFuncionariosNavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.Id, Funcionario.Nome, Funcionario.Contato, Funcionario.Email, Funcionario.Matricula, Funcionario.CPF, Funcionario.Setor, Funcionario.Cargo, EmpresaEntity);

                var Usuario = res.IdUsuariosNavigation;
                var UsuarioEntity = new Usuarios(Usuario.Id, Usuario.Nome, Usuario.Cargo, Usuario.Email, Usuario.Senha);

                return new Setores(res.Id, res.Nome, res.FL_Status, FuncionarioEntity, UsuarioEntity, EmpresaEntity);
            });
        }


    }
}

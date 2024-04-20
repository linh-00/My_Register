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
    public class FuncionariosRepository : IFuncionariosRepository
    {
        private dbMyRegisterContext dbMyRegister;
        public FuncionariosRepository(dbMyRegisterContext dbMyRegister)
        {
            this.dbMyRegister = dbMyRegister;
        }
        public async Task<Funcionarios> InsertFuncionariosAsync(Funcionarios Request)
        {
            Funcionario newFuncionarios = new Funcionario()
            {
                Nome = Request.Nome,
                Contato = Request.Contato,
                Email = Request.Email,
                Matricula = Request.Matricula,
                CPF = Request.CPF,
                Setor = Request.Setor,
                Cargo = Request.Cargo,
            };

            dbMyRegister.Funcionarios.Add(newFuncionarios);
            await dbMyRegister.SaveChangesAsync();
            Request.SetId(newFuncionarios.Id);
            return Request;
        }
        public async Task<IEnumerable<Funcionarios>> GetAllFuncionariosAsync()
        {
            List<Funcionario> entity = await dbMyRegister.Funcionarios
                .Include(x => x.IdEmpresaNavigation)
                .ToListAsync();
            return entity.Select(res =>
            {
                var Empresa = res.IdEmpresaNavigation;
                var EmpresaEntity = new Empresas(Empresa.Id, Empresa.Nome, Empresa.CNPJ, Empresa.Dominio, Empresa.Contato, Empresa.Email, Empresa.Endereco);

                return new Funcionarios(res.Id, res.Nome, res.Contato, res.Email, res.Matricula, res.CPF, res.Setor, res.Cargo, EmpresaEntity);
            });
        }
        public async Task<Funcionarios> GetFuncionariosByIdAsync(int id)
        {
            var entity = await dbMyRegister.Funcionarios
                .Include(x => x.IdEmpresaNavigation)
                .Where(x =>  x.Id == id)
                .FirstAsync();
            if (entity is not null)
            {
                var Empresa = entity.IdEmpresaNavigation;
                var EmpresaEntity = new Empresas(Empresa.Id, Empresa.Nome, Empresa.CNPJ, Empresa.Dominio, Empresa.Contato, Empresa.Email, Empresa.Endereco);

                return new Funcionarios(entity.Id, entity.Nome, entity.Contato, entity.Email, entity.Matricula, entity.CPF, entity.Setor, entity.Cargo, EmpresaEntity);                
            }
            else
                throw new Exception("Funcionário não encontrado");

        }
        public async Task<IEnumerable<Funcionarios>> GetFuncionariosByEmpresaIdAsync(int EmpresaId)
        {
           List<Funcionario> entity = await dbMyRegister
                .Funcionarios
                .Include(x => x.IdEmpresaNavigation)
                .Where(x => x.Id == EmpresaId)
                .ToListAsync();

            return entity.Select(res =>
            {
                var Empresa = res.IdEmpresaNavigation;
                var EmpresaEntity = new Empresas(Empresa.Id, Empresa.Nome, Empresa.CNPJ, Empresa.Dominio, Empresa.Contato, Empresa.Email, Empresa.Endereco);

                return new Funcionarios(res.Id, res.Nome, res.Contato, res.Email, res.Matricula, res.CPF, res.Setor, res.Cargo, EmpresaEntity);
            });          
          
        }       
    }
}

﻿using Inc.MyRegister.DAL.Contexts;
using Inc.MyRegister.DAL.Models;
using Inc.MyRegister.Domain.Entities;
using Inc.MyRegister.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inc.MyRegister.DAL.Repositories
{
    public class RegistroPontoRepository : IRegistroPontosRepository
    {
        private MyRegisterContext dbMyRegister;
        public RegistroPontoRepository(MyRegisterContext dbMyRegister)
        {
            this.dbMyRegister = dbMyRegister;
        }
        public async Task<RegistroPontos> InsertRegistroPontoRepositoryAsync(RegistroPontos Request)
        {
            RegistroPonto newRegistroPonto = new RegistroPonto()
            {
                DT_Ponto = Request.DT_Ponto,
                TP_Ponto = Request.TP_Ponto,
            };
            dbMyRegister.RegistroPontos.Add(newRegistroPonto);
            await dbMyRegister.SaveChangesAsync();
            Request.SetId(newRegistroPonto.Id);
            return Request;
        }

        public async Task<IEnumerable<RegistroPontos>> GetAllRegistroPontosAsync()
        {
            List<RegistroPonto> entity = await dbMyRegister.RegistroPontos
                .Include(x => x.IdFuncionarioNavigation)
                .Include(x => x.IdEmpresaNavigation)
                .ToListAsync();
            return entity.Select(res =>
            {
                var Empresa = res.IdEmpresaNavigation;
                var EmpresaEntity = new Empresas(Empresa.Id, Empresa.Nome, Empresa.CNPJ, Empresa.Dominio, Empresa.Contato, Empresa.Email, Empresa.Endereco);

                var Funcionario = res.IdFuncionarioNavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.Id, Funcionario.Nome, Funcionario.Contato, Funcionario.Email, Funcionario.Matricula, Funcionario.CPF, Funcionario.Setor, Funcionario.Cargo, EmpresaEntity);

                return new RegistroPontos(res.Id, res.TP_Ponto, res.DT_Ponto, FuncionarioEntity);
            });
        }
        public async Task<RegistroPontos> GetRegistroPontosByIdAsync(int Id)
        {
            var entity = await dbMyRegister.RegistroPontos
               .Where(x => x.Id == Id)
               .Include(x => x.IdEmpresaNavigation)
               .Include(x => x.IdFuncionarioNavigation)
               .FirstAsync();
            if (entity is not null)
            {
                var Empresa = entity.IdEmpresaNavigation;
                var EmpresaEntity = new Empresas(Empresa.Id, Empresa.Nome, Empresa.CNPJ, Empresa.Dominio, Empresa.Contato, Empresa.Email, Empresa.Endereco);

                var Funcionario = entity.IdFuncionarioNavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.Id, Funcionario.Nome, Funcionario.Contato, Funcionario.Email, Funcionario.Matricula, Funcionario.CPF, Funcionario.Setor, Funcionario.Cargo, EmpresaEntity);

                return new RegistroPontos(entity.Id, entity.TP_Ponto, entity.DT_Ponto, FuncionarioEntity);
            }
            else
            {
                throw new Exception("Registro de Ponto não encontrado");
            }
        }
        public async Task<IEnumerable<RegistroPontos>> GetRegistroPontoByFuncionarioAsync(int FuncionarioId)
        {
            List<RegistroPonto> entity = await dbMyRegister
                .RegistroPontos
                .Include(x => x.IdEmpresaNavigation)
                .Include(x => x.IdFuncionarioNavigation)
                .Where(x => x.Id == FuncionarioId)
                .ToListAsync();

            return entity.Select(res =>
            {
                var Empresa = res.IdEmpresaNavigation;
                var EmpresaEntity = new Empresas(Empresa.Id, Empresa.Nome, Empresa.CNPJ, Empresa.Dominio, Empresa.Contato, Empresa.Email, Empresa.Endereco);

                var Funcionario = res.IdFuncionarioNavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.Id, Funcionario.Nome, Funcionario.Contato, Funcionario.Email, Funcionario.Matricula, Funcionario.CPF, Funcionario.Setor, Funcionario.Cargo, EmpresaEntity);

                return new RegistroPontos(res.Id, res.TP_Ponto, res.DT_Ponto, FuncionarioEntity);
            });

        }
        public async Task<IEnumerable<RegistroPontos>> GetRegistroPontoByEmpresaAsync(int EmpresaId)
        {
            List<RegistroPonto> entity = await dbMyRegister
                .RegistroPontos
                .Include(x => x.IdEmpresaNavigation)
                .Include(x => x.IdFuncionarioNavigation)
                .Where(x => x.Id == EmpresaId)
                .ToListAsync();

            return entity.Select(res =>
            {
                var Empresa = res.IdEmpresaNavigation;
                var EmpresaEntity = new Empresas(Empresa.Id, Empresa.Nome, Empresa.CNPJ, Empresa.Dominio, Empresa.Contato, Empresa.Email, Empresa.Endereco);

                var Funcionario = res.IdFuncionarioNavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.Id, Funcionario.Nome, Funcionario.Contato, Funcionario.Email, Funcionario.Matricula, Funcionario.CPF, Funcionario.Setor, Funcionario.Cargo, EmpresaEntity);

                return new RegistroPontos(res.Id, res.TP_Ponto, res.DT_Ponto, FuncionarioEntity);
            });
        }
        public async Task<RegistroPontos> UpdateRegistroPontoAsync(RegistroPontos Request)
        {
            var entity = await dbMyRegister.RegistroPontos.Where(x => x.Id == Request.Id).FirstAsync();
            if (entity == null)
            {
                entity.TP_Ponto = Request.TP_Ponto;
                entity.DT_Ponto = Request.DT_Ponto;
                await dbMyRegister.SaveChangesAsync();


                await dbMyRegister.SaveChangesAsync();
                return Request;
            }
            else
                throw new Exception("Registro de Ponto não atualizado");
        }
    }
}

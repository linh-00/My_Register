using Inc.MyRegister.DAL.Context;
using Inc.MyRegister.DAL.Models;
using Inc.MyRegister.Domain.Entities;
using Inc.MyRegister.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empresa = Inc.MyRegister.DAL.Models.Empresa;
using Empresas = Inc.MyRegister.Domain.Entities.Empresas;

namespace Inc.MyRegister.DAL.Repositories
{
    public class EmpresasRepository : IEmpresasRepository
    {
        private dbMyRegisterContext dbMyRegister;
        public EmpresasRepository(dbMyRegisterContext dbMyRegister)
        {
            this.dbMyRegister = dbMyRegister;
        }
        public async Task<Empresas> InsertEmpresaAsync(Empresas Request)
        {
            Empresa newEmpresa = new Empresa()
            {                
                Nome = Request.Nome,
                CNPJ = Request.CNPJ,
                Dominio = Request.Dominio,
                Contato = Request.Contato,
                Email = Request.Email,
                Endereco = Request.Endereco,
            };

            dbMyRegister.Empresas.Add(newEmpresa);
            await dbMyRegister.SaveChangesAsync();
            Request.SetId(newEmpresa.Id);
            return Request;
        }
        public async Task<IEnumerable<Empresas>> GetEmpresasAsync()
        {
            List<Empresa> entity = await dbMyRegister.Empresas.ToListAsync();               
                return entity.Select(res =>
                {
                    return new Empresas(res.Id, res.Nome, res.CNPJ, res.Dominio,res.Contato, res.Email, res.Endereco);
                });               
        }

        public async Task<Empresas> GetEmpresasByIdAsync(int Id)
        {
            var entity = await dbMyRegister.Empresas.Where(x => x.Id == Id).FirstAsync();
            if (entity == null)
            {
                return new Empresas(entity.Id, entity.Nome, entity.CNPJ, entity.Dominio, entity.Contato, entity.Email, entity.Endereco);
            }
            else
                throw new Exception("Empresa não encontrada");
        }

        public async Task<Empresas> UpdateEmpresasAsync(Empresas Request)
        {
            var entity = await dbMyRegister.Empresas.Where(x => x.Id == Request.Id).FirstAsync();
            if (entity == null)
            {
                entity.Nome = Request.Nome;
                entity.CNPJ = Request.CNPJ;
                entity.Dominio = Request.Dominio;
                entity.Contato = Request.Contato;
                entity.Email = Request.Email;
                entity.Endereco = Request.Endereco;

                await dbMyRegister.SaveChangesAsync();
                return Request;
            }
            else
                throw new Exception("Empresa não atualizada");
        }

    }
}

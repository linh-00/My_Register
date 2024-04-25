using Inc.MyRegister.DAL.Contexts;
using Inc.MyRegister.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Empresa = Inc.MyRegister.DAL.Models.EMPRESA;
using Empresas = Inc.MyRegister.Domain.Entities.Empresas;

namespace Inc.MyRegister.DAL.Repositories
{
    public class EmpresasRepository : IEmpresasRepository
    {
        private MyRegisterContext dbMyRegister;
        public EmpresasRepository(MyRegisterContext dbMyRegister)
        {
            this.dbMyRegister = dbMyRegister;
        }
        public async Task<Empresas> InsertEmpresaAsync(Empresas Request)
        {
            Empresa newEmpresa = new Empresa()
            {
                DS_NOME = Request.Nome,
                CNPJ = Request.CNPJ,
                DOMINIO = Request.Dominio,
                CONTATO_COPERATIVO = Request.Contato,
                EMAIL = Request.Email,
                ENDERECO = Request.Endereco,
            };

            dbMyRegister.EMPRESAs.Add(newEmpresa);
            await dbMyRegister.SaveChangesAsync();
            Request.SetId(newEmpresa.ID_EMPRESA);
            return Request;
        }
        public async Task<IEnumerable<Empresas>> GetEmpresasAsync()
        {
            List<Empresa> entity = await dbMyRegister.EMPRESAs.ToListAsync();
            return entity.Select(res =>
            {
                return new Empresas(res.ID_EMPRESA, res.DS_NOME, res.CNPJ, res.DOMINIO, res.CONTATO_COPERATIVO, res.EMAIL, res.ENDERECO);
            });
        }

        public async Task<Empresas> GetEmpresasByIdAsync(int Id)
        {
            var entity = await dbMyRegister.EMPRESAs.Where(x => x.ID_EMPRESA == Id).FirstAsync();
            if (entity == null)
            {
                return new Empresas(entity.ID_EMPRESA, entity.DS_NOME, entity.CNPJ, entity.DOMINIO, entity.CONTATO_COPERATIVO, entity.EMAIL, entity.ENDERECO);
            }
            else
                throw new Exception("Empresa não encontrada");
        }

        public async Task<Empresas> UpdateEmpresasAsync(Empresas Request)
        {
            var entity = await dbMyRegister.EMPRESAs.Where(x => x.ID_EMPRESA == Request.Id).FirstAsync();
            if (entity == null)
            {
                entity.DS_NOME = Request.Nome;
                entity.CNPJ = Request.CNPJ;
                entity.DOMINIO = Request.Dominio;
                entity.CONTATO_COPERATIVO = Request.Contato;
                entity.EMAIL = Request.Email;
                entity.ENDERECO = Request.Endereco;

                await dbMyRegister.SaveChangesAsync();
                return Request;
            }
            else
                throw new Exception("Empresa não atualizada");
        }

    }
}

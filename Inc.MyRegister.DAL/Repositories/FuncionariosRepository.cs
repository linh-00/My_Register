using Inc.MyRegister.DAL.Contexts;
using Inc.MyRegister.DAL.Models;
using Inc.MyRegister.Domain.Entities;
using Inc.MyRegister.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inc.MyRegister.DAL.Repositories
{
    public class FuncionariosRepository : IFuncionariosRepository
    {
        private MyRegisterContext dbMyRegister;
        public FuncionariosRepository(MyRegisterContext dbMyRegister)
        {
            this.dbMyRegister = dbMyRegister;
        }
        public async Task<Funcionarios> InsertFuncionariosAsync(Funcionarios Request)
        {
            FUNCIONARIO newFuncionarios = new FUNCIONARIO()
            {
                DS_NOME = Request.Nome,
                CONTATO_FUNCIONARIO = Request.Contato,
                EMAIL_CORPORATIVO = Request.Email,
                MATRICULA = Request.Matricula,
                CPF = Request.CPF,
                SETOR = Request.Setor,
                CARGO = Request.Cargo,
            };

            dbMyRegister.FUNCIONARIOs.Add(newFuncionarios);
            await dbMyRegister.SaveChangesAsync();
            Request.SetId(newFuncionarios.ID_FUNCIONARIO);
            return Request;
        }
        public async Task<IEnumerable<Funcionarios>> GetAllFuncionariosAsync()
        {
            List<FUNCIONARIO> entity = await dbMyRegister.FUNCIONARIOs
                .Include(x => x.ID_EMPRESANavigation)
                .ToListAsync();
            return entity.Select(res =>
            {
                var Empresa = res.ID_EMPRESANavigation;
                var EmpresaEntity = new Empresas(Empresa.ID_EMPRESA, Empresa.DS_NOME, Empresa.CNPJ, Empresa.DOMINIO, Empresa.CONTATO_COPERATIVO, Empresa.EMAIL, Empresa.ENDERECO);

                return new Funcionarios(res.ID_FUNCIONARIO, res.DS_NOME, res.CONTATO_FUNCIONARIO, res.EMAIL_CORPORATIVO, res.MATRICULA, res.CPF, res.SETOR, res.CARGO, EmpresaEntity);
            });
        }
        public async Task<Funcionarios> GetFuncionariosByIdAsync(int id)
        {
            var entity = await dbMyRegister.FUNCIONARIOs
                .Include(x => x.ID_EMPRESANavigation)
                .Where(x => x.ID_FUNCIONARIO == id)
                .FirstAsync();
            if (entity is not null)
            {
                var Empresa = entity.ID_EMPRESANavigation;
                var EmpresaEntity = new Empresas(Empresa.ID_EMPRESA, Empresa.DS_NOME, Empresa.CNPJ, Empresa.DOMINIO, Empresa.CONTATO_COPERATIVO, Empresa.EMAIL, Empresa.ENDERECO);

                return new Funcionarios(entity.ID_FUNCIONARIO, entity.DS_NOME, entity.CONTATO_FUNCIONARIO, entity.EMAIL_CORPORATIVO, entity.MATRICULA, entity.CPF, entity.SETOR, entity.CARGO, EmpresaEntity);
            }
            else
                throw new Exception("Funcionário não encontrado");

        }
        public async Task<IEnumerable<Funcionarios>> GetFuncionariosByEmpresaIdAsync(int EmpresaId)
        {
            List<FUNCIONARIO> entity = await dbMyRegister
                 .FUNCIONARIOs
                 .Include(x => x.ID_EMPRESANavigation)
                 .Where(x => x.ID_EMPRESA == EmpresaId)
                 .ToListAsync();

            return entity.Select(res =>
            {
                var Empresa = res.ID_EMPRESANavigation;
                var EmpresaEntity = new Empresas(Empresa.ID_EMPRESA, Empresa.DS_NOME, Empresa.CNPJ, Empresa.DOMINIO, Empresa.CONTATO_COPERATIVO, Empresa.EMAIL, Empresa.ENDERECO);

                return new Funcionarios(res.ID_EMPRESA, res.DS_NOME, res.CONTATO_FUNCIONARIO, res.EMAIL_CORPORATIVO, res.MATRICULA, res.CPF, res.SETOR, res.CARGO, EmpresaEntity);
            });

        }
    }
}

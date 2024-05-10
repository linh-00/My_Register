using Inc.MyRegister.DAL.Contexts;
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
            REGISTRO_PONTO newRegistroPonto = new REGISTRO_PONTO()
            {
                DT_PONTO = Request.DT_PONTO,
                TP_Ponto = Request.TP_Ponto
            };
            dbMyRegister.REGISTRO_PONTOs.Add(newRegistroPonto);
            await dbMyRegister.SaveChangesAsync();
            Request.SetId(newRegistroPonto.ID_REGISTRO_PONTO);
            return Request;
        }

        public async Task<IEnumerable<RegistroPontos>> GetAllRegistroPontosAsync()
        {
            List<REGISTRO_PONTO> entity = await dbMyRegister.REGISTRO_PONTOs
                .Include(x => x.ID_FUNCIONARIONavigation)
                .Include(x => x.ID_EMPRESANavigation)
                .ToListAsync();
            return entity.Select(res =>
            {
                var Empresa = res.ID_EMPRESANavigation;
                var EmpresaEntity = new Empresas(Empresa.ID_EMPRESA, Empresa.DS_NOME, Empresa.CNPJ, Empresa.DOMINIO, Empresa.CONTATO_COPERATIVO, Empresa.EMAIL, Empresa.ENDERECO);

                var Funcionario = res.ID_FUNCIONARIONavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.ID_FUNCIONARIO, Funcionario.DS_NOME, Funcionario.CONTATO_FUNCIONARIO, Funcionario.EMAIL_CORPORATIVO, Funcionario.MATRICULA, Funcionario.CPF, Funcionario.SETOR, Funcionario.CARGO, EmpresaEntity);

                return new RegistroPontos(res.ID_FUNCIONARIO, res.DT_PONTO, res.TP_Ponto, FuncionarioEntity, EmpresaEntity);
            });
        }
        public async Task<RegistroPontos> GetRegistroPontosByIdAsync(int Id)
        {
            var entity = await dbMyRegister.REGISTRO_PONTOs
               .Where(x => x.ID_REGISTRO_PONTO == Id)
               .Include(x => x.ID_EMPRESANavigation)
               .Include(x => x.ID_FUNCIONARIONavigation)
               .FirstAsync();
            if (entity is not null)
            {
                var Empresa = entity.ID_EMPRESANavigation;
                var EmpresaEntity = new Empresas(Empresa.ID_EMPRESA, Empresa.DS_NOME, Empresa.CNPJ, Empresa.DOMINIO, Empresa.CONTATO_COPERATIVO, Empresa.EMAIL, Empresa.ENDERECO);

                var Funcionario = entity.ID_FUNCIONARIONavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.ID_EMPRESA, Funcionario.DS_NOME, Funcionario.CONTATO_FUNCIONARIO, Funcionario.EMAIL_CORPORATIVO, Funcionario.MATRICULA, Funcionario.CPF, Funcionario.SETOR, Funcionario.CARGO, EmpresaEntity);

                return new RegistroPontos(entity.ID_REGISTRO_PONTO, entity.DT_PONTO, entity.TP_Ponto, FuncionarioEntity, EmpresaEntity);
            }
            else
            {
                throw new Exception("Registro de Ponto não encontrado");
            }
        }
        public async Task<IEnumerable<RegistroPontos>> GetRegistroPontoByFuncionarioAsync(int FuncionarioId)
        {
            List<REGISTRO_PONTO> entity = await dbMyRegister
                .REGISTRO_PONTOs
                .Include(x => x.ID_EMPRESANavigation)
                .Include(x => x.ID_FUNCIONARIONavigation)
                .Where(x => x.ID_REGISTRO_PONTO == FuncionarioId)
                .ToListAsync();

            return entity.Select(res =>
            {
                var Empresa = res.ID_EMPRESANavigation;
                var EmpresaEntity = new Empresas(Empresa.ID_EMPRESA, Empresa.DS_NOME, Empresa.CNPJ, Empresa.DOMINIO, Empresa.CONTATO_COPERATIVO, Empresa.EMAIL, Empresa.ENDERECO);

                var Funcionario = res.ID_FUNCIONARIONavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.ID_FUNCIONARIO, Funcionario.DS_NOME, Funcionario.CONTATO_FUNCIONARIO, Funcionario.EMAIL_CORPORATIVO, Funcionario.MATRICULA, Funcionario.CPF, Funcionario.SETOR, Funcionario.CARGO, EmpresaEntity);

                return new RegistroPontos(res.ID_REGISTRO_PONTO, res.DT_PONTO, res.TP_Ponto, FuncionarioEntity, EmpresaEntity);
            });

        }
        public async Task<IEnumerable<RegistroPontos>> GetRegistroPontoByEmpresaAsync(int EmpresaId)
        {
            List<REGISTRO_PONTO> entity = await dbMyRegister
                .REGISTRO_PONTOs
                .Include(x => x.ID_EMPRESANavigation)
                .Include(x => x.ID_FUNCIONARIONavigation)
                .Where(x => x.ID_REGISTRO_PONTO == EmpresaId)
                .ToListAsync();

            return entity.Select(res =>
            {
                var Empresa = res.ID_EMPRESANavigation;
                var EmpresaEntity = new Empresas(Empresa.ID_EMPRESA, Empresa.DS_NOME, Empresa.CNPJ, Empresa.DOMINIO, Empresa.CONTATO_COPERATIVO, Empresa.EMAIL, Empresa.ENDERECO);

                var Funcionario = res.ID_FUNCIONARIONavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.ID_FUNCIONARIO, Funcionario.DS_NOME, Funcionario.CONTATO_FUNCIONARIO, Funcionario.EMAIL_CORPORATIVO, Funcionario.MATRICULA, Funcionario.CPF, Funcionario.SETOR, Funcionario.CARGO, EmpresaEntity);

                return new RegistroPontos(res.ID_REGISTRO_PONTO, res.DT_PONTO, res.TP_Ponto, FuncionarioEntity, EmpresaEntity);
            });
        }
        public async Task<RegistroPontos> UpdateRegistroPontoAsync(RegistroPontos Request)
        {
            var entity = await dbMyRegister.REGISTRO_PONTOs.Where(x => x.ID_REGISTRO_PONTO == Request.Id).FirstAsync();
            if (entity == null)
            {
                entity.TP_Ponto = Request.TP_Ponto;
                entity.DT_PONTO = Request.DT_PONTO;
                await dbMyRegister.SaveChangesAsync();


                await dbMyRegister.SaveChangesAsync();
                return Request;
            }
            else
                throw new Exception("Registro de Ponto não atualizado");
        }

    }
}


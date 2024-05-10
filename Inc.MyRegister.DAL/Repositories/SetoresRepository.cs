using Inc.MyRegister.DAL.Contexts;
using Inc.MyRegister.DAL.Models;
using Inc.MyRegister.Domain.Entities;
using Inc.MyRegister.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inc.MyRegister.DAL.Repositories
{
    public class SetoresRepository : ISetorRepository
    {
        private MyRegisterContext dbMyRegister;
        public SetoresRepository(MyRegisterContext dbMyRegister)
        {
            this.dbMyRegister = dbMyRegister;
        }

        public async Task<Setores> InsertSetoresAsync(Setores Request)
        {
            SETOR newSetores = new SETOR()
            {
                DS_NOME = Request.Nome,
                FL_STATUS = Request.FL_Status,
            };
            dbMyRegister.SETORs.Add(newSetores);
            await dbMyRegister.SaveChangesAsync();
            Request.SetId(newSetores.ID_SETOR);
            return Request;
        }
        public async Task<IEnumerable<Setores>> GetAllSetoresAsync()
        {
            List<SETOR> entity = await dbMyRegister.SETORs
                .Include(x => x.ID_USUARIONavigation)
                .Include(x => x.ID_FUNCIONARIOsNavigation)
                .Include(x => x.ID_EMPRESANavigation)
                .ToListAsync();
            return entity.Select(res =>
            {
                var Usuarios = res.ID_USUARIONavigation;
                var UsuariosEntity = new Usuarios(Usuarios.ID_USUARIO, Usuarios.DS_NOME, Usuarios.TP_CARGO, Usuarios.DS_EMAIL, Usuarios.DS_SENHA);

                var Empresas = res.ID_EMPRESANavigation;
                var EmpresaEntity = new Empresas(Empresas.ID_EMPRESA, Empresas.DS_NOME, Empresas.CNPJ, Empresas.DOMINIO, Empresas.CONTATO_COPERATIVO, Empresas.EMAIL, Empresas.ENDERECO);

                var Funcionario = res.ID_FUNCIONARIOsNavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.ID_FUNCIONARIO, Funcionario.DS_NOME, Funcionario.CONTATO_FUNCIONARIO, Funcionario.EMAIL_CORPORATIVO, Funcionario.MATRICULA, Funcionario.CPF, Funcionario.SETOR, Funcionario.CARGO, EmpresaEntity);

                return new Setores(res.ID_FUNCIONARIOs, res.DS_NOME, res.FL_STATUS, FuncionarioEntity, UsuariosEntity, EmpresaEntity);

            });

        }
        public async Task<Setores> GetSetoresByIdAsync(int Id)
        {
            var entity = await dbMyRegister.SETORs
              .Where(x => x.ID_SETOR == Id)
              .Include(x => x.ID_EMPRESANavigation)
              .Include(x => x.ID_FUNCIONARIOsNavigation)
              .Include(x => x.ID_USUARIONavigation)
              .FirstAsync();
            if (entity is not null)
            {
                var Usuarios = entity.ID_USUARIONavigation;
                var UsuariosEntity = new Usuarios(Usuarios.ID_USUARIO, Usuarios.DS_NOME, Usuarios.TP_CARGO, Usuarios.DS_EMAIL, Usuarios.DS_SENHA);

                var Empresa = entity.ID_EMPRESANavigation;
                var EmpresaEntity = new Empresas(Empresa.ID_EMPRESA, Empresa.DS_NOME, Empresa.CNPJ, Empresa.DOMINIO, Empresa.CONTATO_COPERATIVO, Empresa.EMAIL, Empresa.ENDERECO);

                var Funcionario = entity.ID_FUNCIONARIOsNavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.ID_FUNCIONARIO, Funcionario.DS_NOME, Funcionario.CONTATO_FUNCIONARIO, Funcionario.EMAIL_CORPORATIVO, Funcionario.MATRICULA, Funcionario.CPF, Funcionario.SETOR, Funcionario.CARGO, EmpresaEntity);

                return new Setores(entity.ID_SETOR, entity.DS_NOME, entity.FL_STATUS, FuncionarioEntity, UsuariosEntity, EmpresaEntity);
            }
            else
                throw new Exception("Setor não encontrado");
            return new Setores();
        }
        public async Task<IEnumerable<Setores>> GetSetorByEmpresaAsync(int EmpresaId)
        {
            List<SETOR> entity = await dbMyRegister
                .SETORs
                .Include(x => x.ID_EMPRESANavigation)
                .Include(x => x.ID_FUNCIONARIOsNavigation)
                .Include(x => x.ID_USUARIONavigation)
                .Where(x => x.ID_SETOR == EmpresaId)
                .ToListAsync();

            return entity.Select(res =>
            {
                var Empresa = res.ID_EMPRESANavigation;
                var EmpresaEntity = new Empresas(Empresa.ID_EMPRESA, Empresa.DS_NOME, Empresa.CNPJ, Empresa.DOMINIO, Empresa.CONTATO_COPERATIVO, Empresa.EMAIL, Empresa.ENDERECO);

                var Funcionario = res.ID_FUNCIONARIOsNavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.ID_FUNCIONARIO, Funcionario.DS_NOME, Funcionario.CONTATO_FUNCIONARIO, Funcionario.EMAIL_CORPORATIVO, Funcionario.MATRICULA, Funcionario.CPF, Funcionario.SETOR, Funcionario.CARGO, EmpresaEntity);

                var Usuario = res.ID_USUARIONavigation;
                var UsuarioEntity = new Usuarios(Usuario.ID_USUARIO, Usuario.DS_NOME, Usuario.TP_CARGO, Usuario.DS_EMAIL, Usuario.DS_SENHA);

                return new Setores(res.ID_SETOR, res.DS_NOME, res.FL_STATUS, FuncionarioEntity, UsuarioEntity, EmpresaEntity);
            });
            return new List<Setores>();
        }
        public async Task<IEnumerable<Setores>> GetSetorByFuncionarioAsync(int FuncionarioId)
        {
            List<SETOR> entity = await dbMyRegister
                .SETORs
                .Include(x => x.ID_EMPRESANavigation)
                .Include(x => x.ID_FUNCIONARIOsNavigation)
                .Include(x => x.ID_USUARIONavigation)
                .Where(x => x.ID_SETOR == FuncionarioId)
                .ToListAsync();

            return entity.Select(res =>
            {
                var Empresa = res.ID_EMPRESANavigation;
                var EmpresaEntity = new Empresas(Empresa.ID_EMPRESA, Empresa.DS_NOME, Empresa.CNPJ, Empresa.DOMINIO, Empresa.CONTATO_COPERATIVO, Empresa.EMAIL, Empresa.ENDERECO);

                var Funcionario = res.ID_FUNCIONARIOsNavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.ID_FUNCIONARIO, Funcionario.DS_NOME, Funcionario.CONTATO_FUNCIONARIO, Funcionario.EMAIL_CORPORATIVO, Funcionario.MATRICULA, Funcionario.CPF, Funcionario.SETOR, Funcionario.CARGO, EmpresaEntity);

                var Usuario = res.ID_USUARIONavigation;
                var UsuarioEntity = new Usuarios(Usuario.ID_USUARIO, Usuario.DS_NOME, Usuario.TP_CARGO, Usuario.DS_EMAIL, Usuario.DS_SENHA);

                return new Setores(res.ID_SETOR, res.DS_NOME, res.FL_STATUS, FuncionarioEntity, UsuarioEntity, EmpresaEntity);
            });
            return new List<Setores>();
        }
        public async Task<IEnumerable<Setores>> GetSetorByUsuarioAsync(int UsuarioId)
        {
            List<SETOR> entity = await dbMyRegister
                .SETORs
                .Include(x => x.ID_EMPRESANavigation)
                .Include(x => x.ID_FUNCIONARIOsNavigation)
                .Include(x => x.ID_USUARIONavigation)
                .Where(x => x.ID_SETOR == UsuarioId)
                .ToListAsync();

            return entity.Select(res =>
            {
                var Empresa = res.ID_EMPRESANavigation;
                var EmpresaEntity = new Empresas(Empresa.ID_EMPRESA, Empresa.DS_NOME, Empresa.CNPJ, Empresa.DOMINIO, Empresa.CONTATO_COPERATIVO, Empresa.EMAIL, Empresa.ENDERECO);

                var Funcionario = res.ID_FUNCIONARIOsNavigation;
                var FuncionarioEntity = new Funcionarios(Funcionario.ID_FUNCIONARIO, Funcionario.DS_NOME, Funcionario.CONTATO_FUNCIONARIO, Funcionario.EMAIL_CORPORATIVO, Funcionario.MATRICULA, Funcionario.CPF, Funcionario.SETOR, Funcionario.CARGO, EmpresaEntity);

                var Usuario = res.ID_USUARIONavigation;
                var UsuarioEntity = new Usuarios(Usuario.ID_USUARIO, Usuario.DS_NOME, Usuario.TP_CARGO, Usuario.DS_EMAIL, Usuario.DS_SENHA);

                return new Setores(res.ID_SETOR, res.DS_NOME, res.FL_STATUS, FuncionarioEntity, UsuarioEntity, EmpresaEntity);
            });

            return new List<Setores>();

        }



    }
}

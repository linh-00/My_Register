using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Domain.Entities
{
    public class Funcionarios : BaseEntities
    {
        public string Nome { get; private set; }
        public string Contato { get; private set; }
        public string Email { get; private set; }
        public string Matricula { get; private set; }
        public string CPF { get; private set; }
        public string Setor { get; private set; }
        public string Cargo { get; private set; }
        public Empresas Empresa { get; private set; }

        public Funcionarios(int Id
            , string nome
            , string contato
            , string email
            , string matricula
            , string cpf
            , string setor
            , string cargo
            , Empresas empresa
            ) : base (Id)
        {
            Nome = nome;
            Contato = contato;
            Email = email;
            Matricula = matricula;
            CPF = cpf;
            Setor = setor;
            Cargo = cargo;
            Empresa = empresa;
        }
        public Funcionarios(
          string nome
        , string contato
        , string email
        , string matricula
        , string cpf
        , string setor
        , string cargo
        ) : base()
        {
            Nome = nome;
            Contato = contato;
            Email = email;
            Matricula = matricula;
            CPF = cpf;
            Setor = setor;
            Cargo = cargo;
        }

    }
}

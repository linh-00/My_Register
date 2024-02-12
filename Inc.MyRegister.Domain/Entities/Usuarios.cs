using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Domain.Entities
{
    public class Usuarios : BaseEntities
    {
        public string Nome { get; private set; }
        public string Cargo { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public Usuarios(int id
            , string nome
            , string cargo
            , string email
            , string senha
            ) : base(id)
        {
            Nome = nome;
            Cargo = cargo;
            Email = email;
            Senha = senha;
        }
        public Usuarios(
        string nome
        , string cargo
        , string email
        , string senha
        ) : base()
        {
            Nome = nome;
            Cargo = cargo;
            Email = email;
            Senha = senha;
        }


    }
}

using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Domain.Entities
{
    public class Setores : BaseEntities
    {
        public string Nome { get; private set; }
        public bool FL_Status { get; private set; }
        public Funcionarios Funcionarios { get; private set; } 
        public Usuarios Usuarios { get; private set; }
        public Empresas Empresas { get; private set; }

        public Setores(int id
            , string nome
            , bool FL_Status
            , Funcionarios funcionarios
            , Usuarios usuarios
            , Empresas empresas

            ) : base(id)
        {
            Nome = nome;
            this.FL_Status = FL_Status;
            Funcionarios = funcionarios;
            Usuarios = usuarios;
            Empresas = empresas;
        }
        public Setores(
         string nome
       , bool FL_Status
       ) : base()
        {
            Nome = nome;
            this.FL_Status = FL_Status;           
        }
    }
}

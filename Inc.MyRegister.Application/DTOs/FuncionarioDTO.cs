using Inc.MyRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Application.DTOs
{
    public class FuncionarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string Matricula { get; set; }
        public string CPF { get; set; }
        public string Setor { get; set; }
        public string Cargo { get; set; } 
        public Funcionarios ToEntity() 
        {
            return new Funcionarios(Nome, Contato, Email, Matricula, CPF, Setor, Cargo);
        }
    }
}

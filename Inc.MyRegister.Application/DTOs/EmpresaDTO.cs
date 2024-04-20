using Inc.MyRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Application.DTOs
{
    public class EmpresaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string CNPJ { get; set; }
        public string Dominio { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public Empresas ToEntity()
        {
            return new Empresas(Id, Nome, CNPJ, Dominio, Contato, Email, Endereco);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.DAL.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Dominio { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
    }
}

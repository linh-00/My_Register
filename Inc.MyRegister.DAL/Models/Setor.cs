using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.DAL.Models
{
    public class Setor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool FL_Status { get; set; }
        public Funcionario IdFuncionariosNavigation { get; set; }
        public Usuario IdUsuariosNavigation { get; set; }
    }
}

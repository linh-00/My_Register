using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.DAL.Models
{
    public class RegistroPonto
    {
        public int Id { get; set; }
        public string DT_Ponto { get; set; }
        public string TP_Ponto { get; set; }
        public Funcionario IdFuncionarioNavigation { get; set; } = null!;
        public Empresa IdEmpresaNavigation { get; set; } = null!;
    }
}

using Inc.MyRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Application.DTOs
{
    public class RegistroPontoDTO
    {
        public int Id { get; set; }
        public string DT_Ponto { get; set; }
        public string TP_Ponto { get; set; }
        public RegistroPontos ToEntity()
        {
            return new RegistroPontos (DT_Ponto, TP_Ponto);
        }
    }
}

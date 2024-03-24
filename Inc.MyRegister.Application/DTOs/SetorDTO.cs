using Inc.MyRegister.DAL.Models;
using Inc.MyRegister.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Application.DTOs
{
    public class SetorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool FL_Status { get; set; }
        public Setores ToEntity()
        {
            return new Setores(Nome, FL_Status);
        }
    }
}

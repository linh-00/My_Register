using Inc.MyRegister.DAL.Entinties;
using Inc.MyRegister.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empresa = Inc.MyRegister.DAL.Models.Empresa;
using Setors = Inc.MyRegister.DAL.Entinties.Setors;

namespace Inc.MyRegister.DAL.Context
{
    public class dbMyRegisterContext : DbContext
    {
        public dbMyRegisterContext() 
        {
        }
        public dbMyRegisterContext(DbContextOptions<dbMyRegisterContext> options)
       : base(options)
        {
        }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<RegistroPonto> RegistroPontos { get; set; }
        public virtual DbSet<Setor> Setores { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-57AIKQO,6001;Initial Catalog=dbMyRegister;persist security info=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    }
}

using System;
using System.Collections.Generic;

namespace Inc.MyRegister.DAL.Models;

public partial class EMPRESA
{
    public int ID_EMPRESA { get; set; }

    public string DS_NOME { get; set; } = null!;

    public string CNPJ { get; set; } = null!;

    public string DOMINIO { get; set; } = null!;

    public string CONTATO_COPERATIVO { get; set; } = null!;

    public string EMAIL { get; set; } = null!;

    public string ENDERECO { get; set; } = null!;

    public virtual ICollection<FUNCIONARIO> FUNCIONARIOs { get; set; } = new List<FUNCIONARIO>();

    public virtual ICollection<SETOR> SETORs { get; set; } = new List<SETOR>();
}

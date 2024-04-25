using System;
using System.Collections.Generic;

namespace Inc.MyRegister.DAL.Models;

public partial class FUNCIONARIO
{
    public int ID_FUNCIONARIO { get; set; }

    public int ID_EMPRESA { get; set; }

    public string DS_NOME { get; set; } = null!;

    public string CONTATO_FUNCIONARIO { get; set; } = null!;

    public string EMAIL_CORPORATIVO { get; set; } = null!;

    public string MATRICULA { get; set; } = null!;

    public string CPF { get; set; } = null!;

    public string SETOR { get; set; } = null!;

    public string CARGO { get; set; } = null!;

    public virtual EMPRESA ID_EMPRESANavigation { get; set; } = null!;

    public virtual ICollection<REGISTRO_PONTO> REGISTRO_PONTOs { get; set; } = new List<REGISTRO_PONTO>();
}

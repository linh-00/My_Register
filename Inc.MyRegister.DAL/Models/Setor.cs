namespace Inc.MyRegister.DAL.Models;

public partial class SETOR
{
    public int ID_SETOR { get; set; }

    public int ID_FUNCIONARIOs { get; set; }

    public int ID_USUARIO { get; set; }

    public string? DS_NOME { get; set; }

    public bool FL_STATUS { get; set; }

    public int ID_EMPRESA { get; set; }

    public virtual EMPRESA ID_EMPRESANavigation { get; set; } = null!;

    public virtual FUNCIONARIO ID_FUNCIONARIOsNavigation { get; set; } = null!;

    public virtual USUARIO ID_USUARIONavigation { get; set; } = null!;
}

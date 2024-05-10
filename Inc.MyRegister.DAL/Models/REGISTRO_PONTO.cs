namespace Inc.MyRegister.DAL.Models;

public partial class REGISTRO_PONTO
{

    public int ID_REGISTRO_PONTO { get; set; }

    public int ID_FUNCIONARIO { get; set; }

    public DateTime DT_PONTO { get; set; }

    public string TP_Ponto { get; set; } = null!;

    public virtual FUNCIONARIO ID_FUNCIONARIONavigation { get; set; } = null!;

    public virtual EMPRESA ID_EMPRESANavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace Inc.MyRegister.DAL.Models;

public partial class USUARIO
{
    public int ID_USUARIO { get; set; }

    public string DS_NOME { get; set; } = null!;

    public string TP_CARGO { get; set; } = null!;

    public string DS_EMAIL { get; set; } = null!;

    public string DS_SENHA { get; set; } = null!;
}

﻿using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.MyRegister.Application.Interfaces.Funcionarios
{
    public interface IInsertFuncionarioUseCase : IUseCase<FuncionarioDTO, FuncionarioDTO>
    {
    }
}
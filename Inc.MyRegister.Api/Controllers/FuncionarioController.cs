using Inc.MyRegister.Api.Interfaces;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Funcionarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inc.MyRegister.Api.Controllers
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        public readonly IGetAllFuncionarioUseCase _GetAllFuncionarioUseCase;
        public readonly IActionResultConverter _ActionResultConverter;
        public readonly IGetFuncionarioByIdUseCase _GetFuncionarioByIdUseCase;
        public readonly IListFuncionarioByEmpresaUseCase _ListFuncionarioByEmpresaUseCase;
        public readonly IInsertFuncionarioUseCase _InsertFuncionarioUseCase;
        public readonly IUpdateFuncionarioUseCase _UpdateFuncionarioUseCase;

        public FuncionarioController(IGetAllFuncionarioUseCase getAllFuncionarioUseCase, IActionResultConverter actionResultConverter, IGetFuncionarioByIdUseCase getFuncionarioByIdUseCase, IInsertFuncionarioUseCase insertFuncionarioUseCase, IListFuncionarioByEmpresaUseCase listFuncionarioByEmpresaUseCase, IUpdateFuncionarioUseCase updateFuncionarioUseCase)
        {
            _GetAllFuncionarioUseCase = getAllFuncionarioUseCase;
            _ActionResultConverter = actionResultConverter;
            _GetFuncionarioByIdUseCase = getFuncionarioByIdUseCase;
            _InsertFuncionarioUseCase = insertFuncionarioUseCase;
            _ListFuncionarioByEmpresaUseCase = listFuncionarioByEmpresaUseCase;
            _UpdateFuncionarioUseCase = updateFuncionarioUseCase;
        }

        [ProducesResponseType(typeof(FuncionarioDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet("IdFuncionario")]

        public async Task<IActionResult> GetFuncionarioById(int IdFuncionario)
        {
            var result = await _GetFuncionarioByIdUseCase.Execute(IdFuncionario);
            return _ActionResultConverter.Convert(result);
        }

        [ProducesResponseType(typeof(FuncionarioDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet("IdEmpresa")]

        public async Task<IActionResult> GetFuncionarioByEmpresaId(int IdEmpresa)
        {
            var result = await _ListFuncionarioByEmpresaUseCase.Execute(IdEmpresa);
            return _ActionResultConverter.Convert(result);
        }

        [ProducesResponseType(typeof(List<FuncionarioDTO>), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet]

        public async Task<IActionResult> GetAllFuncionario()
        {
            var result = await _GetAllFuncionarioUseCase.Execute();
            return _ActionResultConverter.Convert(result);
        }

        [ProducesResponseType(typeof(FuncionarioDTO), StatusCodes.Status200OK)]
        [HttpPost]

        public async Task<IActionResult> InsertFuncionario(FuncionarioDTO response)
        {
            var result = await _InsertFuncionarioUseCase.Execute(response);
            return _ActionResultConverter.Convert(result);
        }
        [ProducesResponseType(typeof(FuncionarioDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpPut]

        public async Task<IActionResult> UpdateFuncionario(FuncionarioDTO response)
        {
            var result = await _UpdateFuncionarioUseCase.Execute(response);
            return _ActionResultConverter.Convert(result);
        }

    }
}

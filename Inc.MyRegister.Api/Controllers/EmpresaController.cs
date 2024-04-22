using Inc.MyRegister.Api.Interfaces;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Application.Interfaces.Empresas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inc.MyRegister.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmpresaController : ControllerBase
    {
        public readonly IGetEmpresaByIdUseCase _GetEmpresaByIdUseCase;
        public readonly IActionResultConverter _ActionConverter;
        public readonly IInsertEmpresaUseCase _InsertEmpresaUseCase;
        public readonly IListEmpresaUseCase _ListEmpresaUseCase;
        public readonly IUpdateEmpresaUseCase _UpdateEmpresaUseCase;

        public EmpresaController(IGetEmpresaByIdUseCase getEmpresaByIdUseCase, IActionResultConverter actionResultConverter, IInsertEmpresaUseCase insertEmpresaUseCase, IListEmpresaUseCase listEmpresaUseCase,
            IUpdateEmpresaUseCase updateEmpresaUseCase)
        {
            _ActionConverter = actionResultConverter;
            _GetEmpresaByIdUseCase = getEmpresaByIdUseCase;
            _InsertEmpresaUseCase = insertEmpresaUseCase;
            _ListEmpresaUseCase = listEmpresaUseCase;
            _UpdateEmpresaUseCase = updateEmpresaUseCase;
        }

        [ProducesResponseType(typeof(EmpresaDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet("IdEmpresa")]

        public async Task<IActionResult> GetEmpresaByIdUseCase(int IdEmpresa)
        {
            var response = await _GetEmpresaByIdUseCase.Execute(IdEmpresa);
            return _ActionConverter.Convert(response);
        }
        [ProducesResponseType(typeof(List<EmpresaDTO>), StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet]

        public async Task<IActionResult> ListEmpresaUseCase()
        {
            var response = await _ListEmpresaUseCase.Execute();
            return _ActionConverter.Convert(response);
        }

        [ProducesResponseType(typeof(EmpresaDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpPost]

        public async Task<IActionResult> InsertEmpresaUseCase(EmpresaDTO request)
        {
            var response = await _InsertEmpresaUseCase.Execute(request);
            return _ActionConverter.Convert(response);
        }
        [ProducesResponseType(typeof(EmpresaDTO), StatusCodes.Status200OK)]
        [Authorize]
        [HttpPut]

        public async Task<IActionResult> UpdateEmpresa(EmpresaDTO request)
        {
            var response = await _UpdateEmpresaUseCase.Execute(request);
            return _ActionConverter.Convert(response);
        }
    }
}

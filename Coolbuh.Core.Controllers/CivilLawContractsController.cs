using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Commands.CreateCivilLawContract;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Commands.DeleteCivilLawContract;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Commands.UpdateCivilLawContract;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Dto;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Queries.GetCivilLawContractsByParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Договора ГПХ
    /// </summary>
    public class CivilLawContractsController : ApiController
    {
        public CivilLawContractsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список договоров ГПХ
        /// </summary>
        /// <param name="startPeriod">Начало отчетного периода</param>
        /// <param name="endPeriod">Окончание отчетного периода</param>
        /// <param name="departmentId">Идентификатор подразделения</param>
        /// <response code="200">Список договоров ГПХ</response>
        [HttpGet]
        public async Task<List<CivilLawContractDto>> Get(DateTime startPeriod, DateTime endPeriod, int? departmentId)
        {
            return await _mediator.Send(new GetCivilLawContractsByParamsRequest
            {
                StartPeriod = startPeriod,
                EndPeriod = endPeriod,
                DepartmentId = departmentId
            });
        }

        /// <summary>
        /// Создать договор ГПХ
        /// </summary>
        /// <param name="civilLawContract">Параметры для создания договора ГПХ</param>
        /// <response code="200">Созданный договор ГПХ</response>
        [HttpPost]
        public async Task<CivilLawContractDto> Post([FromBody] CreateCivilLawContractDto civilLawContract)
        {
            return await _mediator.Send(new CreateCivilLawContractRequest { CivilLawContract = civilLawContract });
        }

        /// <summary>
        /// Обновить договор ГПХ
        /// </summary>
        /// <param name="civilLawContract">Параметры для обновления договора ГПХ</param>
        /// <response code="200">Обновленный договор ГПХ</response>
        [HttpPut]
        public async Task<CivilLawContractDto> Put([FromBody] UpdateCivilLawContractDto civilLawContract)
        {
            return await _mediator.Send(new UpdateCivilLawContractRequest { CivilLawContract = civilLawContract });
        }

        /// <summary>
        /// Удалить договор ГПХ
        /// </summary>
        /// <param name="civilLawContract">Параметры для удаления договора ГПХ</param>
        /// <response code="200">Удаленный договор ГПХ</response>
        [HttpDelete]
        public async Task<CivilLawContractDto> Delete([FromBody] DeleteCivilLawContractDto civilLawContract)
        {
            return await _mediator.Send(new DeleteCivilLawContractRequest { CivilLawContract = civilLawContract });
        }
    }
}

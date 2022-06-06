using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Commands.CreateListLivingWage;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Commands.DeleteListLivingWage;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Commands.UpdateListLivingWage;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Dto;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Queries.GetListLivingWages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Справочник "Прожиточные минимумы"
    /// </summary>
    public class ListLivingWagesController : ApiController
    {
        public ListLivingWagesController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список прожиточных минимумов
        /// </summary>
        /// <response code="200">Список прожиточных минимумов</response>
        [HttpGet]
        public async Task<List<ListLivingWageDto>> Get()
        {
            return await _mediator.Send(new GetListLivingWagesRequest());
        }

        /// <summary>
        /// Создать прожиточный минимум
        /// </summary>
        /// <param name="livingWage">Параметры для создания прожиточного минимума</param>
        /// <response code="200">Cозданный прожиточный минимум</response>
        [HttpPost]
        public async Task<ListLivingWageDto> Post([FromBody] CreateListLivingWageDto livingWage)
        {
            return await _mediator.Send(new CreateListLivingWageRequest { LivingWage = livingWage });
        }

        /// <summary>
        /// Обновить прожиточный минимум
        /// </summary>
        /// <param name="livingWage">Параметры для обновления прожиточного минимума</param>
        /// <response code="200">Обновленный прожиточный минимум</response>
        [HttpPut]
        public async Task<ListLivingWageDto> Put([FromBody] UpdateListLivingWageDto livingWage)
        {
            return await _mediator.Send(new UpdateListLivingWageRequest { LivingWage = livingWage });
        }

        /// <summary>
        /// Удалить прожиточный минимум
        /// </summary>
        /// <param name="livingWage">Параметры для удаления прожиточного минимума</param>
        /// <response code="200">Удаленный прожиточный минимум</response>
        [HttpDelete]
        public async Task<ListLivingWageDto> Delete([FromBody] DeleteListLivingWageDto livingWage)
        {
            return await _mediator.Send(new DeleteListLivingWageRequest { LivingWage = livingWage });
        }
    }
}

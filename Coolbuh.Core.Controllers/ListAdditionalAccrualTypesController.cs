using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Commands.CreateListAdditionalAccrualType;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Commands.DeleteListAdditionalAccrualType;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Commands.UpdateListAdditionalAccrualType;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Dto;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Queries.GetListAdditionalAccrualTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Справочник "Типы дополнительных начислений"
    /// </summary>
    public class ListAdditionalAccrualTypesController : ApiController
    {
        public ListAdditionalAccrualTypesController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список типов дополнительных начислений
        /// </summary>
        /// <response code="200">Список типов дополнительных начислений</response>
        [HttpGet]
        public async Task<List<ListAdditionalAccrualTypeDto>> Get()
        {
            return await _mediator.Send(new GetListAdditionalAccrualTypesRequest());
        }

        /// <summary>
        /// Создать тип дополнительного начисления
        /// </summary>
        /// <param name="additionalAccrualType">Параметры для создания типа дополнительного начисления</param>
        /// <response code="200">Тип дополнительных начислений</response>
        [HttpPost]
        public async Task<ListAdditionalAccrualTypeDto> Post([FromBody] CreateListAdditionalAccrualTypeDto additionalAccrualType)
        {
            return await _mediator.Send(new CreateListAdditionalAccrualTypeRequest
            {
                AdditionalAccrualType = additionalAccrualType
            });
        }

        /// <summary>
        /// Обновить тип дополнительного начисления
        /// </summary>
        /// <param name="additionalAccrualType">Параметры для обновления типа дополнительного начисления</param>
        /// <response code="200">Тип дополнительных начислений</response>
        [HttpPut]
        public async Task<ListAdditionalAccrualTypeDto> Put([FromBody] UpdateListAdditionalAccrualTypeDto additionalAccrualType)
        {
            return await _mediator.Send(new UpdateListAdditionalAccrualTypeRequest
            {
                AdditionalAccrualType = additionalAccrualType
            });
        }

        /// <summary>
        /// Удалить тип дополнительного начисления
        /// </summary>
        /// <param name="additionalAccrualType">Параметры для удаления типа дополнительного начисления</param>
        /// <response code="200">Тип дополнительных начислений</response>
        [HttpDelete]
        public async Task<ListAdditionalAccrualTypeDto> Delete([FromBody] DeleteListAdditionalAccrualTypeDto additionalAccrualType)
        {
            return await _mediator.Send(new DeleteListAdditionalAccrualTypeRequest
            {
                AdditionalAccrualType = additionalAccrualType
            });
        }
    }
}

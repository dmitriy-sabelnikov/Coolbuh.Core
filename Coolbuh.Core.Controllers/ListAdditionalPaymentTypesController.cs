using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Commands.CreateListAdditionalPaymentType;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Commands.DeleteListAdditionalPaymentType;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Commands.UpdateListAdditionalPaymentType;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Dto;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Queries.GetListAdditionalPaymentTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Справочник "Типы дополнительных выплат"
    /// </summary>
    public class ListAdditionalPaymentTypesController : ApiController
    {
        public ListAdditionalPaymentTypesController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список типов дополнительных выплат
        /// </summary>
        /// <response code="200">Список типов дополнительных выплат</response>
        [HttpGet]
        public async Task<List<ListAdditionalPaymentTypeDto>> Get()
        {
            return await _mediator.Send(new GetListAdditionalPaymentTypesRequest());
        }

        /// <summary>
        /// Создать тип дополнительной выплаты
        /// </summary>
        /// <param name="additionalPaymentType">Параметры для создания типа дополнительной выплаты</param>
        /// <response code="200">Созданный тип дополнительной выплаты</response>
        [HttpPost]
        public async Task<ListAdditionalPaymentTypeDto> Post([FromBody] CreateListAdditionalPaymentTypeDto additionalPaymentType)
        {
            return await _mediator.Send(new CreateListAdditionalPaymentTypeRequest
            {
                AdditionalPaymentType = additionalPaymentType
            });
        }

        /// <summary>
        /// Обновить тип дополнительной выплаты
        /// </summary>
        /// <param name="additionalPaymentType">Параметры для обновления типа дополнительной выплаты</param>
        /// <response code="200">Обновленный тип дополнительной выплаты</response>
        [HttpPut]
        public async Task<ListAdditionalPaymentTypeDto> Put([FromBody] UpdateListAdditionalPaymentTypeDto additionalPaymentType)
        {
            return await _mediator.Send(new UpdateListAdditionalPaymentTypeRequest
            {
                AdditionalPaymentType = additionalPaymentType
            });
        }

        /// <summary>
        /// Удалить тип дополнительной выплаты
        /// </summary>
        /// <param name="additionalPaymentType">Параметры для удаления типа дополнительной выплаты</param>
        /// <response code="200">Удаленный тип дополнительной выплаты</response>
        [HttpDelete]
        public async Task<ListAdditionalPaymentTypeDto> Delete([FromBody] DeleteListAdditionalPaymentTypeDto additionalPaymentType)
        {
            return await _mediator.Send(new DeleteListAdditionalPaymentTypeRequest
            {
                AdditionalPaymentType = additionalPaymentType
            });
        }
    }
}

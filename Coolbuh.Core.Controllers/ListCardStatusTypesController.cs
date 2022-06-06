using Coolbuh.Core.UseCases.Handlers.ListCardStatusTypes.Dto;
using Coolbuh.Core.UseCases.Handlers.ListCardStatusTypes.Queries.GetListCardStatusTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Справочник "Типы статусов карточки"
    /// </summary>
    public class ListCardStatusTypesController : ApiController
    {
        public ListCardStatusTypesController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список типов статусов карточки
        /// </summary>
        /// <response code="200">Список типов статусов карточки</response>
        [HttpGet]
        public async Task<List<ListCardStatusTypeDto>> Get()
        {
            return await _mediator.Send(new GetListCardStatusTypesRequest());
        }
    }
}
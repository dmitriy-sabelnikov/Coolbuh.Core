using Coolbuh.Core.UseCases.Handlers.ListPositions.Dto;
using Coolbuh.Core.UseCases.Handlers.ListPositions.Queries.GetListPositions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Справочник "Должности"
    /// </summary>
    public class ListPositionsController : ApiController
    {
        public ListPositionsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список должностей
        /// </summary>
        /// <response code="200">Список должностей</response>
        [HttpGet]
        public async Task<List<ListPositionDto>> Get()
        {
            return await _mediator.Send(new GetListPositionsRequest());
        }
    }
}
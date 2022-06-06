using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ListLivingWages.Queries.GetListLivingWages
{
    /// <summary>
    /// Объект запроса "Получить список прожиточных минимумов"
    /// </summary>
    public class GetListLivingWagesRequest : IRequest<List<ListLivingWageDto>>
    {
    }
}

using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Queries.GetListSocialBenefits
{
    /// <summary>
    /// Объект запроса "Получить список социальных льгот"
    /// </summary>
    public class GetListSocialBenefitsRequest : IRequest<List<ListSocialBenefitDto>>
    {
    }
}
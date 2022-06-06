using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Commands.CreateListSocialBenefit;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Commands.DeleteListSocialBenefit;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Commands.UpdateListSocialBenefit;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Dto;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Queries.GetListSocialBenefits;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Справочник "Социальные льготы"
    /// </summary>
    public class ListSocialBenefitsController : ApiController
    {
        public ListSocialBenefitsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список социальных льгот
        /// </summary>
        /// <response code="200">Список социальных льгот</response>
        [HttpGet]
        public async Task<List<ListSocialBenefitDto>> Get()
        {
            return await _mediator.Send(new GetListSocialBenefitsRequest());
        }

        /// <summary>
        /// Создать социальную льготу
        /// </summary>
        /// <param name="socialBenefit">Параметры для создания социальной льготы</param>
        /// <response code="200">Созданная социальная льгота</response>
        [HttpPost]
        public async Task<ListSocialBenefitDto> Post([FromBody] CreateListSocialBenefitDto socialBenefit)
        {
            return await _mediator.Send(new CreateListSocialBenefitRequest { SocialBenefit = socialBenefit });
        }

        /// <summary>
        /// Обновить социальную льготу
        /// </summary>
        /// <param name="socialBenefit">Параметры для обновления социальной льготы</param>
        /// <response code="200">Обновленная социальная льгота</response>
        [HttpPut]
        public async Task<ListSocialBenefitDto> Put([FromBody] UpdateListSocialBenefitDto socialBenefit)
        {
            return await _mediator.Send(new UpdateListSocialBenefitRequest { SocialBenefit = socialBenefit });
        }

        /// <summary>
        /// Удалить социальную льготу
        /// </summary>
        /// <param name="socialBenefit">Параметры для удаления социальной льготы</param>
        /// <response code="200">Удаленная социальная льгота</response>
        [HttpDelete]
        public async Task<ListSocialBenefitDto> Delete([FromBody] DeleteListSocialBenefitDto socialBenefit)
        {
            return await _mediator.Send(new DeleteListSocialBenefitRequest { SocialBenefit = socialBenefit });
        }
    }
}
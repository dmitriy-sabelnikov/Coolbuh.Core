using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Commands.UpdateListSocialBenefit
{
    /// <summary>
    /// Объект команды "Обновить социальную льготу"
    /// </summary>
    public class UpdateListSocialBenefitRequest : IRequest<ListSocialBenefitDto>
    {
        /// <inheritdoc cref="UpdateListSocialBenefitDto"/>
        public UpdateListSocialBenefitDto SocialBenefit { get; set; }
    }
}
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Commands.CreateListSocialBenefit
{
    /// <summary>
    /// Объект команды "Создать социальную льготу"
    /// </summary>
    public class CreateListSocialBenefitRequest : IRequest<ListSocialBenefitDto>
    {
        /// <inheritdoc cref="CreateListSocialBenefitDto"/>
        public CreateListSocialBenefitDto SocialBenefit { get; set; }
    }
}
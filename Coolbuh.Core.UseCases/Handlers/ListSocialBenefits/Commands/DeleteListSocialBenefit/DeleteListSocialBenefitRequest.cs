using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Commands.DeleteListSocialBenefit
{
    /// <summary>
    /// Объект команды "Удалить социальную льготу"
    /// </summary>
    public class DeleteListSocialBenefitRequest : IRequest<ListSocialBenefitDto>
    {
        /// <inheritdoc cref="DeleteListSocialBenefitDto"/>
        public DeleteListSocialBenefitDto SocialBenefit { get; set; }
    }
}
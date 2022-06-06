using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListLivingWages.Commands.CreateListLivingWage
{
    /// <summary>
    /// Объект команды "Создать прожиточный минимум"
    /// </summary>
    public class CreateListLivingWageRequest : IRequest<ListLivingWageDto>
    {
        /// <inheritdoc cref="CreateListLivingWageDto"/>
        public CreateListLivingWageDto LivingWage { get; set; }
    }
}

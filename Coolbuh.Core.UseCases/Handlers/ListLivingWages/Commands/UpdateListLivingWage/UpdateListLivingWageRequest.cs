using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListLivingWages.Commands.UpdateListLivingWage
{
    /// <summary>
    /// Объект команды "Обновить прожиточный минимум"
    /// </summary>
    public class UpdateListLivingWageRequest : IRequest<ListLivingWageDto>
    {
        /// <inheritdoc cref="UpdateListLivingWageDto"/>
        public UpdateListLivingWageDto LivingWage { get; set; }
    }
}

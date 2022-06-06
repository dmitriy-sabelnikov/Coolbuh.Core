using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListLivingWages.Commands.DeleteListLivingWage
{
    /// <summary>
    /// Объект команды "Удалить прожиточный минимум"
    /// </summary>
    public class DeleteListLivingWageRequest : IRequest<ListLivingWageDto>
    {
        /// <inheritdoc cref="DeleteListLivingWageDto"/>
        public DeleteListLivingWageDto LivingWage { get; set; }
    }
}

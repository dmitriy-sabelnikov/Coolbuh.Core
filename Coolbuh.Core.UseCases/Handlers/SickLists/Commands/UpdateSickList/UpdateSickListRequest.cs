using Coolbuh.Core.UseCases.Handlers.SickLists.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.SickLists.Commands.UpdateSickList
{
    /// <summary>
    /// Объект команды "Обновить больничный лист"
    /// </summary>
    public class UpdateSickListRequest : IRequest<SickListDto>
    {
        /// <inheritdoc cref="UpdateSickListDto"/> 
        public UpdateSickListDto SickList { get; set; }
    }
}

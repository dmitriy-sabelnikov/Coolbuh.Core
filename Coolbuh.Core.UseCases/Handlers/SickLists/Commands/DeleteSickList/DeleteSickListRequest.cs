using Coolbuh.Core.UseCases.Handlers.SickLists.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.SickLists.Commands.DeleteSickList
{
    /// <summary>
    /// Объект команды "Удалить больничный лист"
    /// </summary>
    public class DeleteSickListRequest : IRequest<SickListDto>
    {
        /// <inheritdoc cref="DeleteSickListDto"/> 
        public DeleteSickListDto SickList { get; set; }
    }
}

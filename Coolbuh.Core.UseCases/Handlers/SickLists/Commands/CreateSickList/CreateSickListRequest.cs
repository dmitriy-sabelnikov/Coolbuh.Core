using Coolbuh.Core.UseCases.Handlers.SickLists.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.SickLists.Commands.CreateSickList
{
    /// <summary>
    /// Объект команды "Создать больничный лист"
    /// </summary>
    public class CreateSickListRequest : IRequest<SickListDto>
    {
        /// <inheritdoc cref="CreateSickListDto"/> 
        public CreateSickListDto SickList { get; set; }
    }
}

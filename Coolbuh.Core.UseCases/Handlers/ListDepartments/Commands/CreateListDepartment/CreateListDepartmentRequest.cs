using Coolbuh.Core.UseCases.Handlers.ListDepartments.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListDepartments.Commands.CreateListDepartment
{
    /// <summary>
    /// Объект команды "Создать подразделение"
    /// </summary>
    public class CreateListDepartmentRequest : IRequest<ListDepartmentDto>
    {
        /// <inheritdoc cref="CreateListDepartmentDto"/>
        public CreateListDepartmentDto Department { get; set; }
    }
}

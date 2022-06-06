using Coolbuh.Core.UseCases.Handlers.ListDepartments.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListDepartments.Commands.DeleteListDepartment
{
    /// <summary>
    /// Объект команды "Удалить подразделение"
    /// </summary>
    public class DeleteListDepartmentRequest : IRequest<ListDepartmentDto>
    {
        /// <inheritdoc cref="DeleteListDepartmentDto"/>
        public DeleteListDepartmentDto Department { get; set; }
    }
}

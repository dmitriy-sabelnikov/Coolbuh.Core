using Coolbuh.Core.UseCases.Handlers.ListDepartments.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListDepartments.Commands.UpdateListDepartment
{
    /// <summary>
    /// Объект команды "Обновить подразделение"
    /// </summary>
    public class UpdateListDepartmentRequest : IRequest<ListDepartmentDto>
    {
        /// <inheritdoc cref="UpdateListDepartmentDto"/>
        public UpdateListDepartmentDto Department { get; set; }
    }
}

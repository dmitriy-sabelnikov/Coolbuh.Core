using Coolbuh.Core.UseCases.Handlers.ListDepartments.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ListDepartments.Queries.GetListDepartments
{
    /// <summary>
    /// Объект запроса "Получить список подразделений"
    /// </summary>
    public class GetListDepartmentsRequest : IRequest<List<ListDepartmentDto>>
    {
    }
}

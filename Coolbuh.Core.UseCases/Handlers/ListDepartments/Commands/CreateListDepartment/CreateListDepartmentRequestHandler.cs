using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Dto;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListDepartments.Commands.CreateListDepartment
{
    /// <summary>
    /// Обработчик команды "Создать подразделение"
    /// </summary>
    public class CreateListDepartmentRequestHandler
        : IRequestHandler<CreateListDepartmentRequest, ListDepartmentDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListDepartmentsService _departmentsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="departmentsService">Доменный сервис справочника "Подразделения"</param>
        public CreateListDepartmentRequestHandler(IDbContext dbContext,
            IListDepartmentsService departmentsService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _departmentsService = departmentsService ?? throw new ArgumentNullException(nameof(departmentsService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Подразделения"</returns>
        public async Task<ListDepartmentDto> Handle(CreateListDepartmentRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Department == null) 
                throw new InvalidOperationException("request.Department is null");

            await CheckListDepartmentAsync(request.Department, cancellationToken);

            var department = request.Department.MapListDepartment();

            _departmentsService.ValidationEntity(department);

            await _dbContext.ListDepartments.AddAsync(department, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return department.MapListDepartmentDto();
        }

        /// <summary>
        /// Проверить валидность DTO создания "Подразделения"
        /// </summary>
        /// <param name="department">DTO создания "Подразделения"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckListDepartmentAsync(CreateListDepartmentDto department, CancellationToken cancellationToken)
        {
            if (department == null) throw new ArgumentNullException(nameof(department));

            if (await _dbContext.ListDepartments.AnyAsync(rec => rec.Code == department.Code, cancellationToken))
                throw new UseCaseException($"Дублікат коду {department.Code} в довіднику");
        }
    }
}

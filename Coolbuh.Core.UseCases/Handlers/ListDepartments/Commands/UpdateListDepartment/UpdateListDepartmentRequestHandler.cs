using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Dto;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListDepartments.Commands.UpdateListDepartment
{
    /// <summary>
    /// Обработчик команды "Обновить подразделение"
    /// </summary>
    public class UpdateListDepartmentRequestHandler
        : IRequestHandler<UpdateListDepartmentRequest, ListDepartmentDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListDepartmentsService _departmentsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="departmentsService">Доменный сервис справочника "Подразделения"</param>
        public UpdateListDepartmentRequestHandler(IDbContext dbContext,
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
        public async Task<ListDepartmentDto> Handle(UpdateListDepartmentRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Department == null) throw new NullReferenceException(nameof(request.Department));

            await CheckListDepartmentAsync(request.Department, cancellationToken);

            var department = request.Department.MapListDepartment();

            _departmentsService.ValidationEntity(department);

            _dbContext.ListDepartments.Update(department);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return department.MapListDepartmentDto();
        }

        /// <summary>
        /// Проверить валидность DTO обновления "Подразделения"
        /// </summary>
        /// <param name="department">DTO обновления "Подразделения"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckListDepartmentAsync(UpdateListDepartmentDto department, CancellationToken cancellationToken)
        {
            if (department == null) throw new ArgumentNullException(nameof(department));

            //Code можно поменять
            var departments = await _dbContext.ListDepartments.AsNoTracking()
                .Where(rec => rec.Code == department.Code || rec.Id == department.Id)
                .ToListAsync(cancellationToken);

            if (departments.Any(rec => rec.Id == department.Id) == false)
                throw new NotFoundEntityUseCaseException($"Відсутній підрозділ в базі (id: {department.Id})");

            if (departments.Any(rec => rec.Id != department.Id))
                throw new UseCaseException($"Дублікат коду {department.Code} в довіднику");
        }
    }
}

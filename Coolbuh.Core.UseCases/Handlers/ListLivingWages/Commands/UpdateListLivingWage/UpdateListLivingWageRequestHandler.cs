using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Dto;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListLivingWages.Commands.UpdateListLivingWage
{
    /// <summary>
    /// Обработчик команды "Обновить прожиточный минимум"
    /// </summary>
    public class UpdateListLivingWageRequestHandler
        : IRequestHandler<UpdateListLivingWageRequest, ListLivingWageDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListLivingWagesService _livingWagesService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="livingWagesService">Доменный сервис справочника "Прожиточные минимумы"</param>
        public UpdateListLivingWageRequestHandler(IDbContext dbContext,
            IListLivingWagesService livingWagesService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _livingWagesService = livingWagesService ?? throw new ArgumentNullException(nameof(livingWagesService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Прожиточный минимум"</returns>
        public async Task<ListLivingWageDto> Handle(UpdateListLivingWageRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.LivingWage == null) throw new InvalidOperationException("request.LivingWage is null");

            var livingWage = request.LivingWage.MapListLivingWage();
            var livingWages = await _dbContext.ListLivingWages.AsNoTracking().ToListAsync(cancellationToken);

            if (!livingWages.Any(rec => rec.Id == livingWage.Id))
                throw new NotFoundEntityUseCaseException($"Відсутній прожитковий мінімум в базі (id: {livingWage.Id})");

            _livingWagesService.ValidationEntity(livingWage);

            if (_livingWagesService.IsExistsPeriodIntersection(livingWage, livingWages))
                throw new UseCaseException("Період перетинається з існуючим");

            _dbContext.ListLivingWages.Update(livingWage);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return livingWage.MapListLivingWageDto();
        }
    }
}

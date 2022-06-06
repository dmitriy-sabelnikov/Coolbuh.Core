using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Dto;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListLivingWages.Commands.CreateListLivingWage
{
    /// <summary>
    /// Обработчик команды "Создать прожиточный минимум"
    /// </summary>
    public class CreateListLivingWageRequestHandler
        : IRequestHandler<CreateListLivingWageRequest, ListLivingWageDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListLivingWagesService _livingWagesService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="livingWagesService">Доменный сервис справочника "Прожиточные минимумы"</param>
        public CreateListLivingWageRequestHandler(IDbContext dbContext,
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
        public async Task<ListLivingWageDto> Handle(CreateListLivingWageRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.LivingWage == null) throw new NullReferenceException(nameof(request.LivingWage));

            var livingWage = request.LivingWage.MapListLivingWage();
            _livingWagesService.ValidationEntity(livingWage);

            var livingWages = await _dbContext.ListLivingWages.AsNoTracking().ToListAsync(cancellationToken);
            if (_livingWagesService.IsExistsPeriodIntersection(livingWage, livingWages))
                throw new UseCaseException("Період перетинається з існуючим");

            await _dbContext.ListLivingWages.AddAsync(livingWage, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return livingWage.MapListLivingWageDto();
        }
    }
}

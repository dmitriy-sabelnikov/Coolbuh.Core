using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Commands.CreateListPensionAllowance
{
    /// <summary>
    /// Обработчик команды "Создать надбавку за пенсию"
    /// </summary>
    public class CreateListPensionAllowanceRequestHandler
        : IRequestHandler<CreateListPensionAllowanceRequest, ListPensionAllowanceDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListPensionAllowancesService _pensionAllowancesService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="pensionAllowancesService">Доменный сервис справочника "Надбавки за пенсию"</param>
        public CreateListPensionAllowanceRequestHandler(IDbContext dbContext,
            IListPensionAllowancesService pensionAllowancesService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _pensionAllowancesService = pensionAllowancesService ??
                                        throw new ArgumentNullException(nameof(pensionAllowancesService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Надбавки за пенсию"</returns>
        public async Task<ListPensionAllowanceDto> Handle(CreateListPensionAllowanceRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.PensionAllowance == null) throw new InvalidOperationException("request.PensionAllowance is null");

            await CheckCreateListPensionAllowanceDtoAsync(request.PensionAllowance, cancellationToken);

            var pensionAllowance = request.PensionAllowance.MapListPensionAllowance();

            _pensionAllowancesService.ValidationEntity(pensionAllowance);

            await _dbContext.ListPensionAllowances.AddAsync(pensionAllowance, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return pensionAllowance.MapListPensionAllowanceDto();
        }

        /// <summary>
        /// Проверить валидность DTO создания "Надбавки за пенсию"
        /// </summary>
        /// <param name="pensionAllowance">DTO создания "Надбавки за пенсию"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckCreateListPensionAllowanceDtoAsync(CreateListPensionAllowanceDto pensionAllowance,
            CancellationToken cancellationToken)
        {
            if (pensionAllowance == null) throw new ArgumentNullException(nameof(pensionAllowance));

            if (await _dbContext.ListPensionAllowances
                .AnyAsync(rec => rec.Code == pensionAllowance.Code, cancellationToken))
                throw new UseCaseException($"Дублікат коду {pensionAllowance.Code} в довіднику");
        }
    }
}

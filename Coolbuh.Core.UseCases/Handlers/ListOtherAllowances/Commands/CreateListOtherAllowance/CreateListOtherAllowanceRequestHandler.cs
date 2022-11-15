using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Commands.CreateListOtherAllowance
{
    /// <summary>
    /// Обработчик команды "Создать другую надбавку"
    /// </summary>
    public class CreateListOtherAllowanceRequestHandler
        : IRequestHandler<CreateListOtherAllowanceRequest, ListOtherAllowanceDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListOtherAllowancesService _otherAllowancesService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="otherAllowancesService">Доменный сервис справочника "Другие надбавки"</param>
        public CreateListOtherAllowanceRequestHandler(IDbContext dbContext,
            IListOtherAllowancesService otherAllowancesService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _otherAllowancesService = otherAllowancesService ??
                                      throw new ArgumentNullException(nameof(otherAllowancesService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Другие надбавки"</returns>
        public async Task<ListOtherAllowanceDto> Handle(CreateListOtherAllowanceRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.OtherAllowance == null) throw new InvalidOperationException("request.OtherAllowance is null");

            await CheckCreateListOtherAllowanceDtoAsync(request.OtherAllowance, cancellationToken);

            var otherAllowance = request.OtherAllowance.MapListOtherAllowance();

            _otherAllowancesService.ValidationEntity(otherAllowance);

            await _dbContext.ListOtherAllowances.AddAsync(otherAllowance, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return otherAllowance.MapListOtherAllowanceDto();
        }

        /// <summary>
        /// Проверить валидность DTO создания "Другие надбавки"
        /// </summary>
        /// <param name="otherAllowance">DTO создания "Другие надбавки"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckCreateListOtherAllowanceDtoAsync(CreateListOtherAllowanceDto otherAllowance,
            CancellationToken cancellationToken)
        {
            if (otherAllowance == null) throw new ArgumentNullException(nameof(otherAllowance));

            if (await _dbContext.ListOtherAllowances
                .AnyAsync(rec => rec.Code == otherAllowance.Code, cancellationToken))
                throw new UseCaseException($"Дублікат коду {otherAllowance.Code} в довіднику");
        }
    }
}

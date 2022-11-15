using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Commands.UpdateListOtherAllowance
{
    /// <summary>
    /// Обработчик команды "Обновить другую надбавку"
    /// </summary>
    public class UpdateListOtherAllowanceRequestHandler
        : IRequestHandler<UpdateListOtherAllowanceRequest, ListOtherAllowanceDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListOtherAllowancesService _otherAllowancesService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="otherAllowancesService">Доменный сервис справочника "Другие надбавки"</param>
        public UpdateListOtherAllowanceRequestHandler(IDbContext dbContext,
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
        public async Task<ListOtherAllowanceDto> Handle(UpdateListOtherAllowanceRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.OtherAllowance == null) throw new InvalidOperationException("request.OtherAllowance is null");

            await CheckUpdateListOtherAllowanceDtoAsync(request.OtherAllowance, cancellationToken);

            var otherAllowance = request.OtherAllowance.MapListOtherAllowance();

            _otherAllowancesService.ValidationEntity(otherAllowance);

            _dbContext.ListOtherAllowances.Update(otherAllowance);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return otherAllowance.MapListOtherAllowanceDto();
        }

        /// <summary>
        /// Проверить валидность DTO обновления "Другие надбавки"
        /// </summary>
        /// <param name="otherAllowance">DTO обновления "Другие надбавки"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckUpdateListOtherAllowanceDtoAsync(UpdateListOtherAllowanceDto otherAllowance,
            CancellationToken cancellationToken)
        {
            if (otherAllowance == null) throw new ArgumentNullException(nameof(otherAllowance));

            //Code можно поменять
            var otherAllowances = await _dbContext.ListOtherAllowances.AsNoTracking()
                .Where(rec => rec.Code == otherAllowance.Code || rec.Id == otherAllowance.Id)
                .ToListAsync(cancellationToken);

            if (!otherAllowances.Any(rec => rec.Id == otherAllowance.Id))
                throw new NotFoundEntityUseCaseException($"Відсутня надбавка в базі (id: {otherAllowance.Id})");

            if (otherAllowances.Any(rec => rec.Id != otherAllowance.Id))
                throw new UseCaseException($"Дублікат коду {otherAllowance.Code} в довіднику");
        }
    }
}

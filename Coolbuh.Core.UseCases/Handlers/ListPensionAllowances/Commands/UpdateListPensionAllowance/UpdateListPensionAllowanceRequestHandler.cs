using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Commands.UpdateListPensionAllowance
{
    /// <summary>
    /// Обработчик команды "Обновить надбавку за пенсию"
    /// </summary>
    public class UpdateListPensionAllowanceRequestHandler
        : IRequestHandler<UpdateListPensionAllowanceRequest, ListPensionAllowanceDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListPensionAllowancesService _pensionAllowancesService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="pensionAllowancesService">Доменный сервис справочника "Надбавки за пенсию"</param>
        public UpdateListPensionAllowanceRequestHandler(IDbContext dbContext,
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
        public async Task<ListPensionAllowanceDto> Handle(UpdateListPensionAllowanceRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.PensionAllowance == null) throw new NullReferenceException(nameof(request.PensionAllowance));

            await CheckUpdateListPensionAllowanceDtoAsync(request.PensionAllowance, cancellationToken);

            var pensionAllowance = request.PensionAllowance.MapListPensionAllowance();

            _pensionAllowancesService.ValidationEntity(pensionAllowance);

            _dbContext.ListPensionAllowances.Update(pensionAllowance);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return pensionAllowance.MapListPensionAllowanceDto();
        }

        /// <summary>
        /// Проверить валидность DTO обновления "Надбавки за пенсию"
        /// </summary>
        /// <param name="pensionAllowance">DTO обновления "Надбавки за пенсию"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        private async Task CheckUpdateListPensionAllowanceDtoAsync(UpdateListPensionAllowanceDto pensionAllowance,
            CancellationToken cancellationToken)
        {
            if (pensionAllowance == null) throw new ArgumentNullException(nameof(pensionAllowance));

            //Code можно поменять
            var pensionAllowances = await _dbContext.ListPensionAllowances.AsNoTracking()
                .Where(rec => rec.Code == pensionAllowance.Code || rec.Id == pensionAllowance.Id)
                .ToListAsync(cancellationToken);

            if (pensionAllowances.Any(rec => rec.Id == pensionAllowance.Id) == false)
                throw new NotFoundEntityUseCaseException($"Відсутня пенсійна надбавка в базі (id: {pensionAllowance.Id})");

            if (pensionAllowances.Any(rec => rec.Id != pensionAllowance.Id))
                throw new UseCaseException($"Дублікат коду {pensionAllowance.Code} в довіднику");
        }
    }
}

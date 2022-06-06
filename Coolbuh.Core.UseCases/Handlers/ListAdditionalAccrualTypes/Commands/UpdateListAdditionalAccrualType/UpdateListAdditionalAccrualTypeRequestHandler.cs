using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Dto;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Commands.UpdateListAdditionalAccrualType
{
    /// <summary>
    /// Обработчик команды "Обновить тип дополнительных начислений"
    /// </summary>
    public class UpdateListAdditionalAccrualTypeRequestHandler
        : IRequestHandler<UpdateListAdditionalAccrualTypeRequest, ListAdditionalAccrualTypeDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListAdditionalAccrualTypesService _additionalAccrualTypeService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="additionalAccrualTypeService">Доменный сервис "Типы дополнительных начислений"</param>
        public UpdateListAdditionalAccrualTypeRequestHandler(IDbContext dbContext,
            IListAdditionalAccrualTypesService additionalAccrualTypeService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _additionalAccrualTypeService = additionalAccrualTypeService ??
                                            throw new ArgumentNullException(nameof(additionalAccrualTypeService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Типы дополнительных начислений"</returns>
        public async Task<ListAdditionalAccrualTypeDto> Handle(UpdateListAdditionalAccrualTypeRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.AdditionalAccrualType == null)
                throw new NullReferenceException(nameof(request.AdditionalAccrualType));

            await CheckUpdateListAdditionalAccrualTypeDtoAsync(request.AdditionalAccrualType, cancellationToken);

            var additionalAccrualType = request.AdditionalAccrualType.MapListAdditionalAccrualType();

            _additionalAccrualTypeService.ValidationEntity(additionalAccrualType);

            _dbContext.ListAdditionalAccrualTypes.Update(additionalAccrualType);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return additionalAccrualType.MapListAdditionalAccrualTypeDto();
        }

        /// <summary>
        /// Проверить валидность DTO обновления "Типы дополнительных начислений"
        /// </summary>
        /// <param name="additionalAccrualType">DTO обновления "Типы дополнительных начислений"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckUpdateListAdditionalAccrualTypeDtoAsync(UpdateListAdditionalAccrualTypeDto additionalAccrualType,
            CancellationToken cancellationToken)
        {
            //Code можно поменять
            var additionalAccrualTypes = await _dbContext.ListAdditionalAccrualTypes.AsNoTracking()
                .Where(rec => rec.Code == additionalAccrualType.Code || rec.Id == additionalAccrualType.Id)
                .ToListAsync(cancellationToken);

            if (additionalAccrualTypes.Any(rec => rec.Id == additionalAccrualType.Id) == false)
                throw new NotFoundEntityUseCaseException(
                    $"Відсутній тип додаткових нарахувань в базі (id: {additionalAccrualType.Id})");

            if (additionalAccrualTypes.Any(rec => rec.Id != additionalAccrualType.Id))
                throw new UseCaseException($"Дублікат коду {additionalAccrualType.Code} в довіднику");
        }
    }
}

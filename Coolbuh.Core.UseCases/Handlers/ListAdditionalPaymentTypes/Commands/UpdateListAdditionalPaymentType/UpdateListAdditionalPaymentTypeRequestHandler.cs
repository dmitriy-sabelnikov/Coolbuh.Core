using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Dto;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Commands.UpdateListAdditionalPaymentType
{
    /// <summary>
    /// Обработчик команды "Обновить тип дополнительных выплат"
    /// </summary>
    public class UpdateListAdditionalPaymentTypeRequestHandler
        : IRequestHandler<UpdateListAdditionalPaymentTypeRequest, ListAdditionalPaymentTypeDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListAdditionalPaymentTypesService _additionalPaymentTypeService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="additionalPaymentTypeService">Доменный сервис справочника "Типы дополнительных выплат"</param>
        public UpdateListAdditionalPaymentTypeRequestHandler(IDbContext dbContext,
            IListAdditionalPaymentTypesService additionalPaymentTypeService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _additionalPaymentTypeService = additionalPaymentTypeService ??
                                            throw new ArgumentNullException(nameof(additionalPaymentTypeService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Типы дополнительных выплат"</returns>
        public async Task<ListAdditionalPaymentTypeDto> Handle(UpdateListAdditionalPaymentTypeRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.AdditionalPaymentType == null)
                throw new NullReferenceException(nameof(request.AdditionalPaymentType));

            await CheckUpdateListAdditionalPaymentTypeDtoAsync(request.AdditionalPaymentType, cancellationToken);

            var additionalPaymentType = request.AdditionalPaymentType.MapListAdditionalPaymentType();

            _additionalPaymentTypeService.ValidationEntity(additionalPaymentType);

            _dbContext.ListAdditionalPaymentTypes.Update(additionalPaymentType);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return additionalPaymentType.MapListAdditionalPaymentTypeDto();
        }

        /// <summary>
        /// Проверить валидность DTO обновления "Типы дополнительных выплат"
        /// </summary>
        /// <param name="additionalPaymentType">DTO обновления "Типы дополнительных выплат"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckUpdateListAdditionalPaymentTypeDtoAsync(UpdateListAdditionalPaymentTypeDto additionalPaymentType,
            CancellationToken cancellationToken)
        {
            if (additionalPaymentType == null) throw new ArgumentNullException(nameof(additionalPaymentType));

            //Code можно поменять
            var additionalPaymentTypes = await _dbContext.ListAdditionalPaymentTypes.AsNoTracking()
                .Where(rec => rec.Code == additionalPaymentType.Code || rec.Id == additionalPaymentType.Id)
                .ToListAsync(cancellationToken);

            if (additionalPaymentTypes.Any(rec => rec.Id == additionalPaymentType.Id) == false)
                throw new NotFoundEntityUseCaseException(
                    $"Відсутній тип додаткових виплат в базі (id: {additionalPaymentType.Id})");

            if (additionalPaymentTypes.Any(rec => rec.Id != additionalPaymentType.Id))
                throw new UseCaseException($"Дублікат коду {additionalPaymentType.Code} в довіднику");
        }
    }
}

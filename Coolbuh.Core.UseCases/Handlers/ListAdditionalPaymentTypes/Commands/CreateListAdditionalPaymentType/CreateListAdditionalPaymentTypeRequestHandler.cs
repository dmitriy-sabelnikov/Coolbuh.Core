using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Dto;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Commands.CreateListAdditionalPaymentType
{
    /// <summary>
    /// Обработчик команды "Создать тип дополнительных выплат"
    /// </summary>
    public class CreateListAdditionalPaymentTypeRequestHandler
        : IRequestHandler<CreateListAdditionalPaymentTypeRequest, ListAdditionalPaymentTypeDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListAdditionalPaymentTypesService _additionalPaymentTypeService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="additionalPaymentTypeService">Доменный сервис справочника "Типы дополнительных выплат"</param>
        public CreateListAdditionalPaymentTypeRequestHandler(IDbContext dbContext,
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
        public async Task<ListAdditionalPaymentTypeDto> Handle(CreateListAdditionalPaymentTypeRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.AdditionalPaymentType == null)
                throw new NullReferenceException(nameof(request.AdditionalPaymentType));

            await CheckCreateListAdditionalPaymentTypeDtoAsync(request.AdditionalPaymentType, cancellationToken);

            var additionalPaymentType = request.AdditionalPaymentType.MapListAdditionalPaymentType();

            _additionalPaymentTypeService.ValidationEntity(additionalPaymentType);

            await _dbContext.ListAdditionalPaymentTypes.AddAsync(additionalPaymentType, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return additionalPaymentType.MapListAdditionalPaymentTypeDto();
        }

        /// <summary>
        /// Проверить валидность DTO создания "Типы дополнительных выплат"
        /// </summary>
        /// <param name="additionalPaymentType">DTO создания "Типы дополнительных выплат"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckCreateListAdditionalPaymentTypeDtoAsync(CreateListAdditionalPaymentTypeDto additionalPaymentType,
            CancellationToken cancellationToken)
        {
            if (additionalPaymentType == null) throw new ArgumentNullException(nameof(additionalPaymentType));

            if (await _dbContext.ListAdditionalPaymentTypes
                .AnyAsync(rec => rec.Code == additionalPaymentType.Code, cancellationToken))
                throw new UseCaseException($"Дублікат коду {additionalPaymentType.Code} в довіднику");
        }
    }
}

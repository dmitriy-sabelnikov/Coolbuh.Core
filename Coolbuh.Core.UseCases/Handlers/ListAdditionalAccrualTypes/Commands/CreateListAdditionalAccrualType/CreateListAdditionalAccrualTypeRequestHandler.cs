using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Dto;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Commands.CreateListAdditionalAccrualType
{
    /// <summary>
    /// Обработчик команды "Создать тип дополнительных начислений"
    /// </summary>
    public class CreateListAdditionalAccrualTypeRequestHandler
        : IRequestHandler<CreateListAdditionalAccrualTypeRequest, ListAdditionalAccrualTypeDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListAdditionalAccrualTypesService _additionalAccrualTypeService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="additionalAccrualTypeService">Доменный сервис "Типы дополнительных начислений"</param>
        public CreateListAdditionalAccrualTypeRequestHandler(IDbContext dbContext,
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
        public async Task<ListAdditionalAccrualTypeDto> Handle(CreateListAdditionalAccrualTypeRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.AdditionalAccrualType == null)
                throw new NullReferenceException(nameof(request.AdditionalAccrualType));

            await CheckCreateListAdditionalAccrualTypeDtoAsync(request.AdditionalAccrualType, cancellationToken);

            var additionalAccrualType = request.AdditionalAccrualType.MapListAdditionalAccrualType();

            _additionalAccrualTypeService.ValidationEntity(additionalAccrualType);

            await _dbContext.ListAdditionalAccrualTypes.AddAsync(additionalAccrualType, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return additionalAccrualType.MapListAdditionalAccrualTypeDto();
        }

        /// <summary>
        /// Проверить валидность DTO создания "Типы дополнительных начислений"
        /// </summary>
        /// <param name="additionalAccrualType">DTO создания "Типы дополнительных начислений"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckCreateListAdditionalAccrualTypeDtoAsync(CreateListAdditionalAccrualTypeDto additionalAccrualType,
            CancellationToken cancellationToken)
        {
            if (additionalAccrualType == null) throw new NullReferenceException(nameof(additionalAccrualType));

            if (await _dbContext.ListAdditionalAccrualTypes
                .AnyAsync(rec => rec.Code == additionalAccrualType.Code, cancellationToken))
                throw new UseCaseException($"Дублікат коду {additionalAccrualType.Code} в довіднику");
        }
    }
}

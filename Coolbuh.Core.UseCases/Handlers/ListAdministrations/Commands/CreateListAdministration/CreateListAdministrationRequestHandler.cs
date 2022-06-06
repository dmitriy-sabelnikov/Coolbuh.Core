using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Dto;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListAdministrations.Commands.CreateListAdministration
{
    /// <summary>
    /// Обработчик команды "Создать администрацию"
    /// </summary>
    public class CreateListAdministrationRequestHandler
        : IRequestHandler<CreateListAdministrationRequest, ListAdministrationDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListAdministrationsService _administrationService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="administrationService">Доменный сервис справочника "Администрации"</param>
        public CreateListAdministrationRequestHandler(IDbContext dbContext,
            IListAdministrationsService administrationService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _administrationService = administrationService ??
                                     throw new ArgumentNullException(nameof(administrationService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Администрации"</returns>
        public async Task<ListAdministrationDto> Handle(CreateListAdministrationRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Administration == null) throw new NullReferenceException(nameof(request.Administration));

            await CheckCreateListAdministrationDtoAsync(request.Administration, cancellationToken);

            var administration = request.Administration.MapListAdministration();

            _administrationService.ValidationEntity(administration);

            await _dbContext.ListAdministrations.AddAsync(administration, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return administration.MapListAdministrationDto();
        }

        /// <summary>
        /// Проверить валидность DTO создания "Администрации"
        /// </summary>
        /// <param name="administration">DTO создания "Администрации"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckCreateListAdministrationDtoAsync(CreateListAdministrationDto administration,
            CancellationToken cancellationToken)
        {
            if (administration == null) throw new ArgumentNullException(nameof(administration));

            if (await _dbContext.ListPositions.AsNoTracking()
                .AnyAsync(rec => rec.Id == administration.PositionId, cancellationToken) == false)
                throw new NotFoundEntityUseCaseException($"Відсутня посада в базі з {administration.PositionId}");
        }
    }
}
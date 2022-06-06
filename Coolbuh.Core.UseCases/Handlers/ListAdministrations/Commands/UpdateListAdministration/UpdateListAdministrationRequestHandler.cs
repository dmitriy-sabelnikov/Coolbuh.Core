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

namespace Coolbuh.Core.UseCases.Handlers.ListAdministrations.Commands.UpdateListAdministration
{
    /// <summary>
    /// Обработчик команды "Обновить администрацию"
    /// </summary>
    public class UpdateListAdministrationRequestHandler
        : IRequestHandler<UpdateListAdministrationRequest, ListAdministrationDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IListAdministrationsService _administrationService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="administrationService">Доменный сервис справочника "Администрации"</param>
        public UpdateListAdministrationRequestHandler(IDbContext dbContext,
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
        public async Task<ListAdministrationDto> Handle(UpdateListAdministrationRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Administration == null) throw new NullReferenceException(nameof(request.Administration));

            await CheckUpdateListAdministrationDtoAsync(request.Administration, cancellationToken);

            var administration = request.Administration.MapListAdministration();

            _administrationService.ValidationEntity(administration);

            _dbContext.ListAdministrations.Update(administration);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return administration.MapListAdministrationDto();
        }

        /// <summary>
        /// Проверить валидность DTO обновления "Администрации"
        /// </summary>
        /// <param name="administration">DTO обновления "Администрации"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckUpdateListAdministrationDtoAsync(UpdateListAdministrationDto administration,
            CancellationToken cancellationToken)
        {
            if (administration == null) throw new ArgumentNullException(nameof(administration));

            if (await _dbContext.ListAdministrations.AsNoTracking()
                .AnyAsync(rec => rec.Id == administration.Id, cancellationToken) == false)
                throw new NotFoundEntityUseCaseException($"Відсутня адміністрація в базі (id: {administration.Id})");

            if (await _dbContext.ListPositions.AsNoTracking()
               .AnyAsync(rec => rec.Id == administration.PositionId, cancellationToken) == false)
                throw new NotFoundEntityUseCaseException($"Відсутня посада в базі з {administration.PositionId}");
        }
    }
}
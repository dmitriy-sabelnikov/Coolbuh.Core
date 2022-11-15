using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Dto;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListAdministrations.Commands.DeleteListAdministration
{
    /// <summary>
    /// Обработчик команды "Удалить администрацию"
    /// </summary>
    public class DeleteListAdministrationRequestHandler
        : IRequestHandler<DeleteListAdministrationRequest, ListAdministrationDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteListAdministrationRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Администрации"</returns>
        public async Task<ListAdministrationDto> Handle(DeleteListAdministrationRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Administration == null) 
                throw new InvalidOperationException("request.Administration is null");

            var administration = await GetListAdministrationAsync(request.Administration.Id, cancellationToken);

            _dbContext.ListAdministrations.Remove(administration);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return administration.MapListAdministrationDto();
        }

        /// <summary>
        /// Получить администрацию
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Администрация</returns>
        private async Task<ListAdministration> GetListAdministrationAsync(int id, CancellationToken cancellationToken)
        {
            var administration = await _dbContext.ListAdministrations.AsNoTracking()
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (administration == null)
                throw new NotFoundEntityUseCaseException($"Відсутня адміністрація в базі (id: {id})");

            return administration;
        }
    }
}
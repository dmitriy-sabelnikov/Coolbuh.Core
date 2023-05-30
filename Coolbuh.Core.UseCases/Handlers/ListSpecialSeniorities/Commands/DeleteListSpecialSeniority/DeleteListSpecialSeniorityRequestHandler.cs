using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Dto;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Commands.DeleteListSpecialSeniority
{
    /// <summary>
    /// Обработчик команды "Удалить спецстаж"
    /// </summary>
    public class DeleteListSpecialSeniorityRequestHandler
        : IRequestHandler<DeleteListSpecialSeniorityRequest, ListSpecialSeniorityDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteListSpecialSeniorityRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Спецстажи"</returns>
        public async Task<ListSpecialSeniorityDto> Handle(DeleteListSpecialSeniorityRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.SpecialSeniority == null)
                throw new InvalidOperationException("request.SpecialSeniority is null");

            var specialSeniority =
                await GetListSpecialSeniorityAsync(request.SpecialSeniority.Id, cancellationToken);

            _dbContext.ListSpecialSeniorities.Remove(specialSeniority);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return specialSeniority.MapListSpecialSeniorityDto();
        }

        /// <summary>
        /// Получить спецстаж
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Спецстаж</returns>
        private async Task<ListSpecialSeniority> GetListSpecialSeniorityAsync(int id,
            CancellationToken cancellationToken)
        {
            var specialSeniority = await _dbContext.ListSpecialSeniorities
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (specialSeniority == null)
                throw new NotFoundEntityUseCaseException($"Відсутній спецстаж в базі (id: {id})");

            return specialSeniority;
        }
    }
}

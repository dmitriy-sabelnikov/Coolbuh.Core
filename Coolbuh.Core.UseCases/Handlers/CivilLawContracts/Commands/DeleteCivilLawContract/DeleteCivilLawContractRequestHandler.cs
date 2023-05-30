using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Dto;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Commands.DeleteCivilLawContract
{
    /// <summary>
    /// Обработчик команды "Удалить договор ГПХ"
    /// </summary>
    public class DeleteCivilLawContractRequestHandler
        : IRequestHandler<DeleteCivilLawContractRequest, CivilLawContractDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteCivilLawContractRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Договор ГПХ"</returns>
        public async Task<CivilLawContractDto> Handle(DeleteCivilLawContractRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.CivilLawContract == null) throw new InvalidOperationException("request.CivilLawContract is null");

            var civilLawContract = await GetCivilLawContractAsync(request.CivilLawContract.Id, cancellationToken);

            _dbContext.CivilLawContracts.Remove(civilLawContract);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return civilLawContract.MapCivilLawContractDto();
        }

        /// <summary>
        /// Получить договор ГПХ
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Договор ГПХ</returns>
        private async Task<CivilLawContract> GetCivilLawContractAsync(int id, CancellationToken cancellationToken)
        {
            var civilLawContract = await _dbContext.CivilLawContracts
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (civilLawContract == null)
                throw new NotFoundEntityUseCaseException($"Відсутній договор ЦПХ в базі (id: {id})");

            return civilLawContract;
        }
    }
}

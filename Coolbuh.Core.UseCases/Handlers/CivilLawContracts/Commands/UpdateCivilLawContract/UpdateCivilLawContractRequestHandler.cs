using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Dto;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Commands.UpdateCivilLawContract
{
    /// <summary>
    /// Обработчик команды "Обновить договор ГПХ"
    /// </summary>
    public class UpdateCivilLawContractRequestHandler
        : IRequestHandler<UpdateCivilLawContractRequest, CivilLawContractDto>
    {
        private readonly IDbContext _dbContext;
        private readonly ICivilLawContractsService _civilLawContractsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="civilLawContractsService">Доменный сервис "Договор ГПХ"</param>
        public UpdateCivilLawContractRequestHandler(IDbContext dbContext, ICivilLawContractsService civilLawContractsService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _civilLawContractsService = civilLawContractsService ??
                                        throw new ArgumentNullException(nameof(civilLawContractsService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Договор ГПХ"</returns>
        public async Task<CivilLawContractDto> Handle(UpdateCivilLawContractRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.CivilLawContract == null) throw new NullReferenceException(nameof(request.CivilLawContract));

            await CheckUpdateCivilLawContractDtoAsync(request.CivilLawContract, cancellationToken);

            var civilLawContract = request.CivilLawContract.MapCivilLawContract();

            _civilLawContractsService.ValidationEntity(civilLawContract);

            _dbContext.CivilLawContracts.Update(civilLawContract);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return civilLawContract.MapCivilLawContractDto();
        }

        /// <summary>
        /// Проверить валидность DTO обновления "Договор ГПХ"
        /// </summary>
        /// <param name="civilLawContract">DTO обновления "Договор ГПХ"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckUpdateCivilLawContractDtoAsync(UpdateCivilLawContractDto civilLawContract,
            CancellationToken cancellationToken)
        {
            if (civilLawContract == null) throw new NullReferenceException(nameof(civilLawContract));

            if (await _dbContext.CivilLawContracts.AsNoTracking()
                .AnyAsync(rec => rec.Id == civilLawContract.Id, cancellationToken) == false)
                throw new NotFoundEntityUseCaseException($"Відсутній договор ЦПХ в базі (id: {civilLawContract.Id})");

            if (await _dbContext.EmployeeCards.AsNoTracking()
                .AnyAsync(rec => rec.Id == civilLawContract.EmployeeCardId, cancellationToken) == false)
                throw new NotFoundEntityUseCaseException(
                    $"Відсутня картка робітника в базі з {civilLawContract.EmployeeCardId}");

            if (await _dbContext.ListDepartments.AsNoTracking()
                .AnyAsync(rec => rec.Id == civilLawContract.DepartmentId, cancellationToken) == false)
                throw new NotFoundEntityUseCaseException($"Відсутній підрозділ в базі з {civilLawContract.DepartmentId}");
        }
    }
}

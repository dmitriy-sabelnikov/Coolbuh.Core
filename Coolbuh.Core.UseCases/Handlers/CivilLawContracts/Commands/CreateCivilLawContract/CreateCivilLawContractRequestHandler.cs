using Coolbuh.Core.DomainServices.Interfaces;
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

namespace Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Commands.CreateCivilLawContract
{
    /// <summary>
    /// Обработчик команды "Создать договор ГПХ"
    /// </summary>
    public class CreateCivilLawContractRequestHandler
        : IRequestHandler<CreateCivilLawContractRequest, CivilLawContractDto>
    {
        private readonly IDbContext _dbContext;
        private readonly ICivilLawContractsService _civilLawContractsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="civilLawContractsService">Доменный сервис "Договор ГПХ"</param>
        public CreateCivilLawContractRequestHandler(IDbContext dbContext,
            ICivilLawContractsService civilLawContractsService)
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
        public async Task<CivilLawContractDto> Handle(CreateCivilLawContractRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.CivilLawContract == null) throw new InvalidOperationException("request.CivilLawContract is null");

            await CheckCreateCivilLawContractDtoAsync(request.CivilLawContract, cancellationToken);

            var civilLawContract = request.CivilLawContract.MapCivilLawContract();

            _civilLawContractsService.ValidationEntity(civilLawContract);

            await _dbContext.CivilLawContracts.AddAsync(civilLawContract, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return civilLawContract.MapCivilLawContractDto();
        }

        /// <summary>
        /// Проверить валидность DTO создания "Договор ГПХ"
        /// </summary>
        /// <param name="civilLawContract">DTO создания "Договор ГПХ"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        private async Task CheckCreateCivilLawContractDtoAsync(CreateCivilLawContractDto civilLawContract,
            CancellationToken cancellationToken)
        {
            if (civilLawContract == null) throw new ArgumentNullException(nameof(civilLawContract));

            if (!await _dbContext.EmployeeCards.AsNoTracking()
                .AnyAsync(rec => rec.Id == civilLawContract.EmployeeCardId, cancellationToken))
                throw new NotFoundEntityUseCaseException(
                    $"Відсутня картка робітника в базі з {civilLawContract.EmployeeCardId}");

            if (!await _dbContext.ListDepartments.AsNoTracking()
                .AnyAsync(rec => rec.Id == civilLawContract.DepartmentId, cancellationToken))
                throw new NotFoundEntityUseCaseException(
                    $"Відсутній підрозділ в базі з {civilLawContract.DepartmentId}");
        }
    }
}

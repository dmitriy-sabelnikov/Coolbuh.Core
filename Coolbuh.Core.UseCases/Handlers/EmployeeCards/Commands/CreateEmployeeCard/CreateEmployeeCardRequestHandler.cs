using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.CreateEmployeeCard
{
    /// <summary>
    /// Обработчик команды "Создать карточку работника"
    /// </summary>
    public class CreateEmployeeCardRequestHandler
        : IRequestHandler<CreateEmployeeCardRequest, EmployeeCardDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IEmployeeCardsService _employeeCardsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="employeeCardsService">Доменный сервис "Карточки работника"</param>
        public CreateEmployeeCardRequestHandler(IDbContext dbContext,
            IEmployeeCardsService employeeCardsService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _employeeCardsService = employeeCardsService ??
                                    throw new ArgumentNullException(nameof(employeeCardsService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Карточка работника"</returns>
        public async Task<EmployeeCardDto> Handle(CreateEmployeeCardRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.EmployeeCard == null) throw new NullReferenceException(nameof(request.EmployeeCard));

            await CheckCreateEmployeeCardDtoAsync(request.EmployeeCard, cancellationToken);

            var employeeCard = request.EmployeeCard.MapEmployeeCard();

            _employeeCardsService.ValidationEntity(employeeCard);

            await _dbContext.EmployeeCards.AddAsync(employeeCard, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return employeeCard.MapEmployeeCardDto();
        }

        /// <summary>
        /// Проверить валидность DTO создания "Карточка работника"
        /// </summary>
        /// <param name="employeeCard">DTO создания "Карточка работника"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckCreateEmployeeCardDtoAsync(CreateEmployeeCardDto employeeCard, CancellationToken cancellationToken)
        {
            if (employeeCard == null) throw new NullReferenceException(nameof(employeeCard));

            if (await _dbContext.EmployeeCards
                .AnyAsync(rec => rec.TaxIdentificationNumber == employeeCard.TaxIdentificationNumber, cancellationToken))
                throw new UseCaseException($"Картка робітника з ІПН {employeeCard.TaxIdentificationNumber} вже існує");
        }
    }
}

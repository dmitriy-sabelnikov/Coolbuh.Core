using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.UpdateEmployeeCard
{
    /// <summary>
    /// Обработчик команды "Обновить карточку работника"
    /// </summary>
    public class UpdateEmployeeCardRequestHandler
        : IRequestHandler<UpdateEmployeeCardRequest, EmployeeCardDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IEmployeeCardsService _employeeCardsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="employeeCardsService">Доменный сервис "Карточки работника"</param>
        public UpdateEmployeeCardRequestHandler(IDbContext dbContext, IEmployeeCardsService employeeCardsService)
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
        public async Task<EmployeeCardDto> Handle(UpdateEmployeeCardRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.EmployeeCard == null) throw new NullReferenceException(nameof(request.EmployeeCard));

            await CheckUpdateEmployeeCardDtoAsync(request.EmployeeCard, cancellationToken);

            var employeeCard = request.EmployeeCard.MapEmployeeCard();

            _employeeCardsService.ValidationEntity(employeeCard);

            // Статус
            if (employeeCard.EmployeeCardStatuses != null)
            {
                var noDeleteCardStatuses = employeeCard.EmployeeCardStatuses.Where(d => d.Id > 0).ToList();
                if (noDeleteCardStatuses.Count > 0)
                {
                    var deleteCardStatuses = await _dbContext.EmployeeCardStatuses.AsNoTracking()
                        .Where(rec => rec.EmployeeCardId == employeeCard.Id && !noDeleteCardStatuses.Contains(rec))
                        .ToListAsync(cancellationToken);
                    _dbContext.EmployeeCardStatuses.RemoveRange(deleteCardStatuses);
                }

            }

            // Дети
            if (employeeCard.EmployeeChildren != null)
            {
                var noDeleteChildren = employeeCard.EmployeeChildren.Where(d => d.Id > 0).ToList();
                if (noDeleteChildren.Count > 0)
                {
                    var deleteChildren = await _dbContext.EmployeeChildren.AsNoTracking()
                        .Where(rec => rec.EmployeeCardId == employeeCard.Id && !noDeleteChildren.Contains(rec))
                        .ToListAsync(cancellationToken);
                    _dbContext.EmployeeChildren.RemoveRange(deleteChildren);

                }
            }

            // Инвалидность
            if (employeeCard.EmployeeDisabilities != null)
            {
                var noDeleteDisabilities = employeeCard.EmployeeDisabilities.Where(d => d.Id > 0).ToList();
                if (noDeleteDisabilities.Count > 0)
                {
                    var deleteDisabilities = await _dbContext.EmployeeDisabilities.AsNoTracking()
                        .Where(rec => rec.EmployeeCardId == employeeCard.Id && !noDeleteDisabilities.Contains(rec))
                        .ToListAsync(cancellationToken);
                    _dbContext.EmployeeDisabilities.RemoveRange(deleteDisabilities);
                }
            }

            // Спецстаж
            if (employeeCard.EmployeeSpecialSeniorities != null)
            {
                var noDeleteSpecialSeniorities = employeeCard.EmployeeSpecialSeniorities.Where(d => d.Id > 0).ToList();
                if (noDeleteSpecialSeniorities.Count > 0)
                {
                    var deleteSpecialSeniorities = await _dbContext.EmployeeSpecialSeniorities.AsNoTracking()
                        .Where(rec => rec.EmployeeCardId == employeeCard.Id && !noDeleteSpecialSeniorities.Contains(rec))
                        .ToListAsync(cancellationToken);
                    _dbContext.EmployeeSpecialSeniorities.RemoveRange(deleteSpecialSeniorities);
                }
            }

            // Налоговые льготы
            if (employeeCard.EmployeeTaxReliefs != null)
            {
                var noDeleteTaxReliefs = employeeCard.EmployeeTaxReliefs.Where(d => d.Id > 0).ToList();
                if (noDeleteTaxReliefs.Count > 0)
                {
                    var deleteTaxReliefs = await _dbContext.EmployeeTaxReliefs.AsNoTracking()
                        .Where(rec => rec.EmployeeCardId == employeeCard.Id && !noDeleteTaxReliefs.Contains(rec))
                        .ToListAsync(cancellationToken);
                    _dbContext.EmployeeTaxReliefs.RemoveRange(deleteTaxReliefs);
                }
            }

            _dbContext.EmployeeCards.Update(employeeCard);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return employeeCard.MapEmployeeCardDto();
        }

        /// <summary>
        /// Проверить валидность DTO обновления "Карточка работника"
        /// </summary>
        /// <param name="employeeCard">DTO обновления "Карточка работника"</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        private async Task CheckUpdateEmployeeCardDtoAsync(UpdateEmployeeCardDto employeeCard, CancellationToken cancellationToken)
        {
            if (employeeCard == null) throw new NullReferenceException(nameof(employeeCard));

            //ИНН можно поменять
            var employeeCards = await _dbContext.EmployeeCards.AsNoTracking().Where(rec =>
                    rec.TaxIdentificationNumber == employeeCard.TaxIdentificationNumber || rec.Id == employeeCard.Id)
                .ToListAsync(cancellationToken);

            if (employeeCards.Any(rec => rec.Id == employeeCard.Id) == false)
                throw new NotFoundEntityUseCaseException($"Відсутня картка робітника в базі (id: {employeeCard.Id})");

            if (employeeCards.Any(rec => rec.Id != employeeCard.Id))
                throw new UseCaseException($"Картка робітника з ІПН {employeeCard.TaxIdentificationNumber} вже існує");
        }
    }
}

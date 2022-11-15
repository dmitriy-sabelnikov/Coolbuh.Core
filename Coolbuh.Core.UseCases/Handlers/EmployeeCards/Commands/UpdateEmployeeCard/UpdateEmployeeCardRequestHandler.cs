using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
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
            if (request.EmployeeCard == null) throw new InvalidOperationException("request.EmployeeCard is null");

            await CheckUpdateEmployeeCardDtoAsync(request.EmployeeCard, cancellationToken);

            var employeeCard = request.EmployeeCard.MapEmployeeCard();

            _employeeCardsService.ValidationEntity(employeeCard);

            // Удаление статусов карточек работника
            await RemoveCardStatuses(employeeCard.Id, employeeCard.EmployeeCardStatuses, cancellationToken);

            // Удаление детей работника
            await RemoveChildren(employeeCard.Id, employeeCard.EmployeeChildren, cancellationToken);

            // Удаление инвалидностей работника
            await RemoveDisabilities(employeeCard.Id, employeeCard.EmployeeDisabilities, cancellationToken);

            // Удаление спецстажей работника
            await RemoveSpecialSeniorities(employeeCard.Id, employeeCard.EmployeeSpecialSeniorities, cancellationToken);

            // Удаление налоговых льгот
            await RemoveTaxReliefs(employeeCard.Id, employeeCard.EmployeeTaxReliefs, cancellationToken);


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
            if (employeeCard == null) throw new ArgumentNullException(nameof(employeeCard));

            //ИНН можно поменять
            var employeeCards = await _dbContext.EmployeeCards.AsNoTracking().Where(rec =>
                    rec.TaxIdentificationNumber == employeeCard.TaxIdentificationNumber || rec.Id == employeeCard.Id)
                .ToListAsync(cancellationToken);

            if (!employeeCards.Any(rec => rec.Id == employeeCard.Id))
                throw new NotFoundEntityUseCaseException($"Відсутня картка робітника в базі (id: {employeeCard.Id})");

            if (employeeCards.Any(rec => rec.Id != employeeCard.Id))
                throw new UseCaseException($"Картка робітника з ІПН {employeeCard.TaxIdentificationNumber} вже існує");
        }

        /// <summary>
        /// Удаление статусов карточки работника
        /// </summary>
        /// <param name="employeeCardId">Идентификатор карточки работника</param>
        /// <param name="cardStatuses">Список статусов</param>
        /// <param name="cancellationToken">Токен отмены</param>
        private async Task RemoveCardStatuses(int employeeCardId, 
            IEnumerable<EmployeeCardStatus> cardStatuses, CancellationToken cancellationToken)
        {
            if (cardStatuses == null)
                return;

            var noDeleteCardStatuses = cardStatuses.Where(d => d.Id > 0).ToList();

            var deleteCardStatuses = await _dbContext.EmployeeCardStatuses.AsNoTracking()
                .Where(rec => rec.EmployeeCardId == employeeCardId && !noDeleteCardStatuses.Contains(rec))
                .ToListAsync(cancellationToken);
            
            _dbContext.EmployeeCardStatuses.RemoveRange(deleteCardStatuses);
        }

        /// <summary>
        /// Удаление детей работника
        /// </summary>
        /// <param name="employeeCardId">Идентификатор карточки работника</param>
        /// <param name="children">Список детей</param>
        /// <param name="cancellationToken">Токен отмены</param>
        private async Task RemoveChildren(int employeeCardId, 
            IEnumerable<EmployeeChildren> children, CancellationToken cancellationToken)
        {
            if (children == null)
                return;

            var noDeleteChildren = children.Where(d => d.Id > 0).ToList();
            
            var deleteChildren = await _dbContext.EmployeeChildren.AsNoTracking()
                .Where(rec => rec.EmployeeCardId == employeeCardId && !noDeleteChildren.Contains(rec))
                .ToListAsync(cancellationToken);

            _dbContext.EmployeeChildren.RemoveRange(deleteChildren);
        }

        /// <summary>
        /// Удаление инвалидностей работника
        /// </summary>
        /// <param name="employeeCardId">Идентификатор карточки работника</param>
        /// <param name="disabilities">Список инвалидностей</param>
        /// <param name="cancellationToken">Токен отмены</param>
        private async Task RemoveDisabilities(int employeeCardId, 
            IEnumerable<EmployeeDisability> disabilities, CancellationToken cancellationToken)
        {
            if (disabilities == null)
                return;

            var noDeleteDisabilities = disabilities.Where(d => d.Id > 0).ToList();
                var deleteDisabilities = await _dbContext.EmployeeDisabilities.AsNoTracking()
                    .Where(rec => rec.EmployeeCardId == employeeCardId && !noDeleteDisabilities.Contains(rec))
                    .ToListAsync(cancellationToken);
            
            _dbContext.EmployeeDisabilities.RemoveRange(deleteDisabilities);
        }

        /// <summary>
        /// Удаление спецстажей работника
        /// </summary>
        /// <param name="employeeCardId">Идентификатор карточки работника</param>
        /// <param name="specialSeniorities">Список спецстажей</param>
        /// <param name="cancellationToken">Токен отмены</param>
        private async Task RemoveSpecialSeniorities(int employeeCardId, 
            IEnumerable<EmployeeSpecialSeniority> specialSeniorities, CancellationToken cancellationToken)
        {
            if (specialSeniorities == null)
                return;
            
            var noDeleteSpecialSeniorities = specialSeniorities.Where(d => d.Id > 0).ToList();
            
            var deleteSpecialSeniorities = await _dbContext.EmployeeSpecialSeniorities.AsNoTracking()
                .Where(rec => rec.EmployeeCardId == employeeCardId && !noDeleteSpecialSeniorities.Contains(rec))
                .ToListAsync(cancellationToken);
            
            _dbContext.EmployeeSpecialSeniorities.RemoveRange(deleteSpecialSeniorities);
        }

        /// <summary>
        /// Удаление налоговых льгот работника
        /// </summary>
        /// <param name="employeeCardId">Идентификатор карточки работника</param>
        /// <param name="taxReliefs">Список налоговых льгот</param>
        /// <param name="cancellationToken">Токен отмены</param>
        private async Task RemoveTaxReliefs(int employeeCardId, 
            IEnumerable<EmployeeTaxRelief> taxReliefs, CancellationToken cancellationToken)
        {
            if(taxReliefs == null)
                return;

            var noDeleteTaxReliefs = taxReliefs.Where(d => d.Id > 0).ToList();
            
            var deleteTaxReliefs = await _dbContext.EmployeeTaxReliefs.AsNoTracking()
                .Where(rec => rec.EmployeeCardId == employeeCardId && !noDeleteTaxReliefs.Contains(rec))
                .ToListAsync(cancellationToken);
            
            _dbContext.EmployeeTaxReliefs.RemoveRange(deleteTaxReliefs);
        }
    }
}

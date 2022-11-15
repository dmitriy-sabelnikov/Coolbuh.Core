using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.CalculateEmployeeCard
{
    /// <summary>
    /// Обработчик команды "Рассчитать карточку работника"
    /// </summary>    
    public class CalculateEmployeeCardRequestHandler : IRequestHandler<CalculateEmployeeCardRequest, CalculatedEmployeeCardDto>
    {
        private readonly ITaxIdentificationNumberService _taxIdentificationNumberService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="taxIdentificationNumberService">Доменный сервис "Идентификационный номер"</param>
        public CalculateEmployeeCardRequestHandler(ITaxIdentificationNumberService taxIdentificationNumberService)
        {
            _taxIdentificationNumberService = taxIdentificationNumberService ??
                                              throw new ArgumentNullException(nameof(taxIdentificationNumberService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Расчитанные параметры"</returns>
        public async Task<CalculatedEmployeeCardDto> Handle(CalculateEmployeeCardRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.EmployeeCard == null) throw new InvalidOperationException("request.EmployeeCard is null");

            var taxIdentificationNumber = request.EmployeeCard.TaxIdentificationNumber;

            return await Task.Run(() =>
            {
                _taxIdentificationNumberService.ValidationTaxIdentificationNumber(taxIdentificationNumber);

                var birthDate = _taxIdentificationNumberService.GetBirthDate(taxIdentificationNumber);
                var sex = _taxIdentificationNumberService.GetSex(taxIdentificationNumber);

                return new CalculatedEmployeeCardDto
                {
                    BirthDate = birthDate,
                    Sex = sex
                };
            }, cancellationToken);
        }
    }
}

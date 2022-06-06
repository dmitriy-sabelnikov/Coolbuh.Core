using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IListAdministrationsService"/>
    public class ListAdministrationsService : IListAdministrationsService
    {
        private readonly ITaxIdentificationNumberService _taxIdentificationNumberService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="taxIdentificationNumberService">Сервис работы с ИНН</param>
        public ListAdministrationsService(ITaxIdentificationNumberService taxIdentificationNumberService)
        {
            _taxIdentificationNumberService = taxIdentificationNumberService;
        }

        /// <inheritdoc/> 
        public void ValidationEntity(ListAdministration administration)
        {
            if (administration == null) throw new ArgumentNullException(nameof(administration));

            if (string.IsNullOrEmpty(administration.FullName))
                throw new NotValidEntityEntityException("Не заповнений ПІБ");

            if (administration.FullName.Length > ListAdministrationConstants.FullNameLength)
                throw new NotValidEntityEntityException($"Довжина ПІБ не повинна перевищувати " +
                    $"{ListAdministrationConstants.FullNameLength}");

            if (string.IsNullOrEmpty(administration.TelephoneNumber))
                throw new NotValidEntityEntityException("Не заповнений номер телефону");

            if (administration.TelephoneNumber.Length > ListAdministrationConstants.TelephoneNumberLength)
                throw new NotValidEntityEntityException($"Довжина телефонного номеру не повинна перевищувати " +
                    $"{ListAdministrationConstants.TelephoneNumberLength}");

            if (administration.PositionId == 0)
                throw new NotValidEntityEntityException("Не заповнена посада");

            _taxIdentificationNumberService.ValidationTaxIdentificationNumber(administration.TaxIdentificationNumber);
        }
    }
}
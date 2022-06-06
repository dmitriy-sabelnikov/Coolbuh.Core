using Coolbuh.Core.Entities.Enums;
using System;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис "Идентификационный номер"
    /// </summary>
    public interface ITaxIdentificationNumberService
    {
        /// <summary>
        /// Валидация ИНН
        /// </summary>
        /// <param name="taxIdentificationNumber">ИНН</param>
        void ValidationTaxIdentificationNumber(string taxIdentificationNumber);

        /// <summary>
        /// Получить дату рождения из ИНН
        /// </summary>
        /// <param name="taxIdentificationNumber">ИНН</param>
        /// <returns>Дата рождения</returns>
        DateTime GetBirthDate(string taxIdentificationNumber);

        /// <summary>
        /// Получить пол из ИНН
        /// </summary>
        /// <param name="taxIdentificationNumber">ИНН</param>
        /// <returns>Пол</returns>
        EmployeeCardSex GetSex(string taxIdentificationNumber);
    }
}

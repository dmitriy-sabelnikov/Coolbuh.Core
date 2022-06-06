using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Entities.Exceptions;
using System;
using System.Linq;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="ITaxIdentificationNumberService"/>
    public class TaxIdentificationNumberService : ITaxIdentificationNumberService
    {
        public void ValidationTaxIdentificationNumber(string taxIdentificationNumber)
        {
            if (string.IsNullOrEmpty(taxIdentificationNumber))
                throw new NotValidEntityEntityException("Не заповнений ІПН");

            if (taxIdentificationNumber.Length != 10)
                throw new NotValidEntityEntityException("Довжина ІПН повинна складати 10 цифр");

            //Контроль алфавита
            short[] coefficients = { 10, 5, 7, 9, 4, 6, 10, 5, 7 };
            if (taxIdentificationNumber.Any(digit => !char.IsDigit(digit)))
                throw new NotValidEntityEntityException("ІПН повинен складатися тільки з цифр");

            var sum = coefficients.Select((coefficient, index) =>
                coefficient * (int)char.GetNumericValue(taxIdentificationNumber, index)).Sum();

            var checkSum = sum % 11 % 10;
            var lastDigit = (int)char.GetNumericValue(taxIdentificationNumber, taxIdentificationNumber.Length - 1);

            if (checkSum != lastDigit)
                throw new NotValidEntityEntityException("В ІПН не співпадає контрольна сума з останньою цифрою");
        }

        public DateTime GetBirthDate(string taxIdentificationNumber)
        {
            var startDate = new DateTime(1899, 12, 31);
            if (taxIdentificationNumber.Length < 5)
                throw new DomainException("Не можливо визначити дату народження з ІПН");

            var stringDays = taxIdentificationNumber[..5];
            if (!long.TryParse(stringDays, out var days))
                throw new DomainException("Не можливо перетворити string в int");

            return startDate.AddDays(days);
        }

        public EmployeeCardSex GetSex(string taxIdentificationNumber)
        {
            if (taxIdentificationNumber.Length < 9)
                throw new DomainException("Не можливо визначити стать з ІПН");

            if (!int.TryParse(taxIdentificationNumber[8].ToString(), out var nineDigit))
                throw new DomainException("Не можливо перетворити char в int");

            return nineDigit % 2 > 0 ? EmployeeCardSex.Male : EmployeeCardSex.Female;
        }
    }
}

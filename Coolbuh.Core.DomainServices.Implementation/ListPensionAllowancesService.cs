using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IListPensionAllowancesService"/>
    public class ListPensionAllowancesService : IListPensionAllowancesService
    {
        public void ValidationEntity(ListPensionAllowance pensionAllowance)
        {
            if (pensionAllowance == null) throw new ArgumentNullException(nameof(pensionAllowance));

            if (string.IsNullOrEmpty(pensionAllowance.Code))
                throw new NotValidEntityEntityException("Не заповнений код");

            if (pensionAllowance.Code.Length > ListPensionAllowanceConstants.CodeLength)
                throw new NotValidEntityEntityException($"Довжина коду не повинна перевищувати " +
                    $"{ListPensionAllowanceConstants.CodeLength}");

            if (string.IsNullOrEmpty(pensionAllowance.Name))
                throw new NotValidEntityEntityException("Не заповнене найменування");

            if (pensionAllowance.Name.Length > ListPensionAllowanceConstants.NameLength)
                throw new NotValidEntityEntityException($"Довжина найменування повинна перевищувати " +
                    $"{ListPensionAllowanceConstants.NameLength}");

            if (pensionAllowance.Percent == 0)
                throw new NotValidEntityEntityException("Не заповнений відсоток");
        }
    }
}
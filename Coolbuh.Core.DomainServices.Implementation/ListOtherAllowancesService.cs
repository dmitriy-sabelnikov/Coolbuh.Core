using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IListOtherAllowancesService"/>
    public class ListOtherAllowancesService : IListOtherAllowancesService
    {
        public void ValidationEntity(ListOtherAllowance otherAllowance)
        {
            if (otherAllowance == null) throw new ArgumentNullException(nameof(otherAllowance));

            if (string.IsNullOrEmpty(otherAllowance.Code))
                throw new NotValidEntityEntityException("Не заповнений код");

            if (otherAllowance.Code.Length > ListOtherAllowanceConstants.CodeLength)
                throw new NotValidEntityEntityException($"Довжина коду не повинна перевищувати " +
                    $"{ListOtherAllowanceConstants.CodeLength}");

            if (string.IsNullOrEmpty(otherAllowance.Name))
                throw new NotValidEntityEntityException("Не заповнене найменування");

            if (otherAllowance.Name.Length > ListOtherAllowanceConstants.NameLength)
                throw new NotValidEntityEntityException($"Довжина найменування не повинна перевищувати " +
                    $"{ListOtherAllowanceConstants.NameLength}");

            if (otherAllowance.Percent == 0)
                throw new NotValidEntityEntityException("Не заповнений відсоток");
        }
    }
}
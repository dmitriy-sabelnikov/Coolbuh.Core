using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IListAdditionalPaymentTypesService"/>
    public class ListAdditionalPaymentTypesService : IListAdditionalPaymentTypesService
    {
        public void ValidationEntity(ListAdditionalPaymentType additionalPaymentType)
        {
            if (additionalPaymentType == null) throw new ArgumentNullException(nameof(additionalPaymentType));

            if (string.IsNullOrEmpty(additionalPaymentType.Code))
                throw new NotValidEntityEntityException("Не заповнений код");

            if (additionalPaymentType.Code.Length > ListAdditionalPaymentTypeConstants.CodeLength)
                throw new NotValidEntityEntityException($"Довжина коду не повинна перевищувати " +
                    $"{ListAdditionalPaymentTypeConstants.CodeLength}");

            if (string.IsNullOrEmpty(additionalPaymentType.Name))
                throw new NotValidEntityEntityException("Не заповнене найменування");

            if (additionalPaymentType.Name.Length > ListAdditionalPaymentTypeConstants.NameLength)
                throw new NotValidEntityEntityException($"Довжина найменування не повинна перевищувати " +
                    $"{ListAdditionalPaymentTypeConstants.NameLength}");
        }
    }
}
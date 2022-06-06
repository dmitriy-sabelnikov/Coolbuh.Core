using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IListAdditionalAccrualTypesService"/>
    public class ListAdditionalAccrualTypesService : IListAdditionalAccrualTypesService
    {
        public void ValidationEntity(ListAdditionalAccrualType additionalAccrualType)
        {
            if (additionalAccrualType == null) throw new ArgumentNullException(nameof(additionalAccrualType));

            if (string.IsNullOrEmpty(additionalAccrualType.Code))
                throw new NotValidEntityEntityException("Не заповнений код");

            if (additionalAccrualType.Code.Length > ListAdditionalAccrualTypeConstants.CodeLength)
                throw new NotValidEntityEntityException($"Довжина коду не повинна перевищувати " +
                    $"{ListAdditionalAccrualTypeConstants.CodeLength}");

            if (string.IsNullOrEmpty(additionalAccrualType.Name))
                throw new NotValidEntityEntityException("Не заповнене найменування");

            if (additionalAccrualType.Name.Length > ListAdditionalAccrualTypeConstants.NameLength)
                throw new NotValidEntityEntityException($"Довжина найменування не повинна перевищувати " +
                    $"{ListAdditionalAccrualTypeConstants.NameLength}");
        }
    }
}
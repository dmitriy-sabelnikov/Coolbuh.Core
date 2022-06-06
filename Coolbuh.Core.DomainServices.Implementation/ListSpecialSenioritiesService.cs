using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IListSpecialSenioritiesService"/>
    public class ListSpecialSenioritiesService : IListSpecialSenioritiesService
    {
        public void ValidationEntity(ListSpecialSeniority specialSeniority)
        {
            if (specialSeniority == null) throw new ArgumentNullException(nameof(specialSeniority));

            if (string.IsNullOrEmpty(specialSeniority.Code))
                throw new NotValidEntityEntityException("Не заповнений код");

            if (specialSeniority.Code.Length > ListSpecialSeniorityConstants.CodeLength)
                throw new NotValidEntityEntityException($"Довжина коду не повинна перевищувати " +
                    $"{ListSpecialSeniorityConstants.CodeLength}");

            if (string.IsNullOrEmpty(specialSeniority.ReasonCode))
                throw new NotValidEntityEntityException("Не заповнений код підстави");

            if (specialSeniority.ReasonCode?.Length > ListSpecialSeniorityConstants.ReasonCodeLength)
                throw new NotValidEntityEntityException($"Довжина коду підстави не повинна перевищувати " +
                    $"{ListSpecialSeniorityConstants.ReasonCodeLength}");

            if (string.IsNullOrEmpty(specialSeniority.Name))
                throw new NotValidEntityEntityException("Не заповнене найменування");

            if (specialSeniority.Name.Length > ListSpecialSeniorityConstants.NameLength)
                throw new NotValidEntityEntityException($"Довжина найменування не повинна перевищувати " +
                    $"{ListSpecialSeniorityConstants.NameLength}");
        }
    }
}
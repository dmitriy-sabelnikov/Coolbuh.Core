using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IListGradeAllowancesService"/>
    public class ListGradeAllowancesService : IListGradeAllowancesService
    {
        public void ValidationEntity(ListGradeAllowance gradeAllowance)
        {
            if (gradeAllowance == null) throw new ArgumentNullException(nameof(gradeAllowance));

            if (string.IsNullOrEmpty(gradeAllowance.Code))
                throw new NotValidEntityEntityException("Не заповнений код");

            if (gradeAllowance.Code.Length > ListGradeAllowanceConstants.CodeLength)
                throw new NotValidEntityEntityException($"Довжина коду не повинна перевищувати " +
                    $"{ListGradeAllowanceConstants.CodeLength}");

            if (string.IsNullOrEmpty(gradeAllowance.Name))
                throw new NotValidEntityEntityException("Не заповнене найменування");

            if (gradeAllowance.Name.Length > ListGradeAllowanceConstants.NameLength)
                throw new NotValidEntityEntityException($"Довжина найменування не повинна перевищувати " +
                    $"{ListGradeAllowanceConstants.NameLength}");

            if (gradeAllowance.Percent == 0)
                throw new NotValidEntityEntityException("Не заповнений відсоток");
        }
    }
}
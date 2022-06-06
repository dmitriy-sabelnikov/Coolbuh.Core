using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IListDepartmentsService"/>
    public class ListDepartmentsService : IListDepartmentsService
    {
        public void ValidationEntity(ListDepartment department)
        {
            if (department == null) throw new ArgumentNullException(nameof(department));

            if (string.IsNullOrEmpty(department.Code))
                throw new NotValidEntityEntityException("Не заповнений код");

            if (department.Code.Length > ListDepartmentConstants.CodeLength)
                throw new NotValidEntityEntityException($"Довжина коду не повинна перевищувати " +
                    $"{ListDepartmentConstants.CodeLength}");

            if (string.IsNullOrEmpty(department.Name))
                throw new NotValidEntityEntityException("Не заповнене найменування");

            if (department.Name.Length > ListDepartmentConstants.NameLength)
                throw new NotValidEntityEntityException($"Довжина найменування не повинна перевищувати " +
                    $"{ListDepartmentConstants.NameLength}");
        }
    }
}
using Coolbuh.Core.Entities.Enums;
using System;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard
{
    /// <summary>
    /// DTO "Расчитанные параметры карточки работника"
    /// </summary>
    public class CalculatedEmployeeCardDto
    {
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public EmployeeCardSex? Sex { get; set; }
    }
}

using System;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Dto
{
    /// <summary>
    /// DTO создания "Дополнительное начисление"
    /// </summary>
    public class CreateAdditionalAccrualDto
    {
        /// <summary>
        /// Идентификатор карточки работника
        /// </summary>
        public int EmployeeCardId { get; set; }

        /// <summary>
        /// Идентификатор подразделения
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Отчетный период
        /// </summary>
        public DateTime AccountingPeriod { get; set; }

        /// <summary>
        /// Идентификатор типа начисления
        /// </summary>
        public int AdditionalAccrualTypeId { get; set; }

        /// <summary>
        /// Сумма начисления
        /// </summary>
        public decimal Sum { get; set; }
    }
}

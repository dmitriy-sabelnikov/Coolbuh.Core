using System;

namespace Coolbuh.Core.UseCases.Handlers.Payments.Dto
{
    /// <summary>
    /// DTO создания "Выплата"
    /// </summary>
    public class CreatePaymentDto
    {
        /// <summary>
        /// Идентификатор карточки работника
        /// </summary>
        public int EmployeeCardId { get; set; }

        /// <summary>
        /// Отчетный период
        /// </summary>
        public DateTime AccountingPeriod { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Sum { get; set; }
    }
}

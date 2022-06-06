using System;

namespace Coolbuh.Core.UseCases.Handlers.Payments.Dto
{
    /// <summary>
    /// DTO обновления "Выплата"
    /// </summary>
    public class UpdatePaymentDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

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

using System;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Дополнительная выплата
    /// </summary>
    public class AdditionalPayment
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
        /// Идентификатор типа дополнительных выплат
        /// </summary>
        public int AdditionalPaymentTypeId { get; set; }

        /// <summary>
        /// Отчетный период
        /// </summary>
        public DateTime AccountingPeriod { get; set; }

        /// <summary>
        /// Сумма выплаты
        /// </summary>
        public decimal Sum { get; set; }

        /// <inheritdoc cref="Models.EmployeeCard"/>
        public virtual EmployeeCard EmployeeCard { get; set; }

        /// <inheritdoc cref="ListAdditionalPaymentType"/>
        public virtual ListAdditionalPaymentType AdditionalPaymentType { get; set; }
    }
}

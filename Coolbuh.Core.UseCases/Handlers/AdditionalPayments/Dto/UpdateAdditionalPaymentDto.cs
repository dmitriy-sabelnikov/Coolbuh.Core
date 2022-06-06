using System;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Dto
{
    /// <summary>
    /// DTO обновления "Дополнительная выплата"
    /// </summary>
    public class UpdateAdditionalPaymentDto
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
    }
}

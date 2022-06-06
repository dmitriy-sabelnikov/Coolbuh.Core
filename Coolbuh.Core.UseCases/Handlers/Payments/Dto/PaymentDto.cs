using System;

namespace Coolbuh.Core.UseCases.Handlers.Payments.Dto
{
    /// <summary>
    /// DTO "Выплата"
    /// </summary>
    public class PaymentDto
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
        /// Фимилия и инициалы работника
        /// </summary>
        public string EmployeeFullName { get; set; }

        /// <summary>
        /// ИНН работника
        /// </summary>
        public string EmployeeTaxIdentificationNumber { get; set; }

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

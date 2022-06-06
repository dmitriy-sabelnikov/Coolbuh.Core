using System;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Dto
{
    /// <summary>
    /// DTO "Дополнительная выплата"
    /// </summary>
    public class AdditionalPaymentDto
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
        /// Идентификатор типа дополнительных выплат
        /// </summary>
        public int AdditionalPaymentTypeId { get; set; }

        /// <summary>
        /// Наименование типа дополнительных выплат
        /// </summary>
        public string AdditionalPaymentTypeName { get; set; }

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

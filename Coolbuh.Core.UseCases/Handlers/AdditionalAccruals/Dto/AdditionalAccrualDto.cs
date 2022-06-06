using System;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Dto
{
    /// <summary>
    /// DTO "Дополнительное начисление"
    /// </summary>
    public class AdditionalAccrualDto
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
        /// Идентификатор подразделения
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Наименование подразделения
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Отчетный период
        /// </summary>
        public DateTime AccountingPeriod { get; set; }

        /// <summary>
        /// Идентификатор типа начисления
        /// </summary>
        public int AdditionalAccrualTypeId { get; set; }

        /// <summary>
        /// Наименование типа начисления
        /// </summary>
        public string AdditionalAccrualTypeName { get; set; }

        /// <summary>
        /// Сумма начисления
        /// </summary>
        public decimal Sum { get; set; }
    }
}

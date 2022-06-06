using System;

namespace Coolbuh.Core.UseCases.Handlers.Vocations.Dto
{
    /// <summary>
    /// DTO "Отпуск"
    /// </summary>
    public class VocationDto
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
        /// Период за который проводится начисление
        /// </summary>
        public DateTime AccrualPeriod { get; set; }

        /// <summary>
        /// Дни
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Sum { get; set; }
    }
}

using System;

namespace Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Dto
{
    /// <summary>
    /// DTO создания "Договор ГПХ"
    /// </summary>
    public class CreateCivilLawContractDto
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
        /// Период, за который проводится начисление
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

using System;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeTaxRelief
{
    /// <summary>
    /// DTO создания "Налоговая льгота"
    /// </summary>
    public class CreateEmployeeTaxReliefDto
    {
        /// <summary>
        /// Период. Начало
        /// </summary>
        public DateTime? PeriodBegin { get; set; }

        /// <summary>
        /// Период. Конец
        /// </summary>
        public DateTime? PeriodEnd { get; set; }

        /// <summary>
        /// Коэффициент льготы
        /// </summary>
        public decimal Сoefficient { get; set; }
    }
}

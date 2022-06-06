namespace Coolbuh.Core.UseCases.Handlers.Salaries.Dto
{
    /// <summary>
    /// DTO "Рассчитать зарплату"
    /// </summary>
    public class CalculateSalaryDto
    {
        /// <summary>
        /// Базовая сумма(ставка)
        /// </summary>
        public decimal BaseSum { get; set; }

        /// <summary>
        /// Идентификатор надбавки пенсионеру
        /// </summary>
        public int? PensionAllowanceId { get; set; }

        /// <summary>
        /// Сумма надбавки пенсионеру
        /// </summary>
        public decimal PensionAllowanceSum { get; set; }

        /// <summary>
        /// Идентификатор надбавки за классность
        /// </summary>
        public int? GradeAllowanceId { get; set; }

        /// <summary>
        /// Сумма надбавки за классность
        /// </summary>
        public decimal GradeAllowanceSum { get; set; }

        /// <summary>
        /// Идентификатор других надбавки 
        /// </summary>
        public int? OtherAllowanceId { get; set; }

        /// <summary>
        /// Сумма других надбавки
        /// </summary>
        public decimal OtherAllowanceSum { get; set; }
    }
}
namespace Coolbuh.Core.UseCases.Handlers.Salaries.Dto
{
    /// <summary>
    /// DTO "Рассчитанная зарплата"
    /// </summary>
    public class CalculatedSalaryDto
    {
        /// <summary>
        /// Базовая сумма(ставка)
        /// </summary>
        public decimal BaseSum { get; set; }

        /// <summary>
        /// Сумма надбавки пенсионеру
        /// </summary>
        public decimal PensionAllowanceSum { get; set; }

        /// <summary>
        /// Сумма надбавки за классность
        /// </summary>
        public decimal GradeAllowanceSum { get; set; }

        /// <summary>
        /// Сумма других надбавки
        /// </summary>
        public decimal OtherAllowanceSum { get; set; }

        /// <summary>
        /// Итоговая сумма
        /// </summary>
        public decimal TotalSum { get; set; }
    }
}

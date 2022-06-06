namespace Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto
{
    /// <summary>
    /// DTO "Надбавки за классность"
    /// </summary>
    public class ListGradeAllowanceDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Процент
        /// </summary>
        public decimal Percent { get; set; }

        /// <summary>
        /// Условие применения. Классность
        /// </summary>
        public int? Grade { get; set; }

        /// <summary>
        /// Условие применения. Идентификатор подразделения
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Условие применения. Наименование подразделения
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Флаг применения надбавки
        /// </summary>
        public bool UseAllowance { get; set; }
    }
}

namespace Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Dto
{
    /// <summary>
    /// DTO "Надбавки за пенсию"
    /// </summary>
    public class ListPensionAllowanceDto
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
        /// Флаг применения надбавки
        /// </summary>
        public bool UseAllowance { get; set; }
    }
}

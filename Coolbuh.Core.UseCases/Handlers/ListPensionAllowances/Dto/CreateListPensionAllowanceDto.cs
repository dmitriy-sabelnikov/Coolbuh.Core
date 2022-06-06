namespace Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Dto
{
    /// <summary>
    /// DTO создания "Надбавки за пенсию"
    /// </summary>
    public class CreateListPensionAllowanceDto
    {
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

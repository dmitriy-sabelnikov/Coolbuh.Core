namespace Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Dto
{
    /// <summary>
    /// DTO создания "Другие надбавки"
    /// </summary>
    public class CreateListOtherAllowanceDto
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

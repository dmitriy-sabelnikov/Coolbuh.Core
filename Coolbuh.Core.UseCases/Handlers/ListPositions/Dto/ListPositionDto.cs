namespace Coolbuh.Core.UseCases.Handlers.ListPositions.Dto
{
    /// <summary>
    /// DTO "Должности"
    /// </summary>
    public class ListPositionDto
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
    }
}
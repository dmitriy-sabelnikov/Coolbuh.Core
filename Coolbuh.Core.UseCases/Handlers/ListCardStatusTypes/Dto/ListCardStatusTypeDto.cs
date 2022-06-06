namespace Coolbuh.Core.UseCases.Handlers.ListCardStatusTypes.Dto
{
    /// <summary>
    /// DTO "Типы статусов карточки"
    /// </summary>
    public class ListCardStatusTypeDto
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
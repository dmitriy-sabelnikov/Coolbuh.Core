namespace Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Dto
{
    /// <summary>
    /// DTO обновления "Спецстажи"
    /// </summary>
    public class UpdateListSpecialSeniorityDto
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
        /// Код основания
        /// </summary>
        public string ReasonCode { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
    }
}

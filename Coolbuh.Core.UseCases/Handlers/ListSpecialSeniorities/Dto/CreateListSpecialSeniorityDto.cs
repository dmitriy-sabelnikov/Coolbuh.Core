namespace Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Dto
{
    /// <summary>
    /// DTO создания "Спецстажи" 
    /// </summary>
    public class CreateListSpecialSeniorityDto
    {
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

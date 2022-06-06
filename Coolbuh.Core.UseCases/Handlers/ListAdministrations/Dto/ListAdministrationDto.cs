namespace Coolbuh.Core.UseCases.Handlers.ListAdministrations.Dto
{
    /// <summary>
    /// DTO "Администрации"
    /// </summary>
    public class ListAdministrationDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string TaxIdentificationNumber { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// Идентификатор должности
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// Наименование должности
        /// </summary>
        public string PositionName { get; set; }
    }
}
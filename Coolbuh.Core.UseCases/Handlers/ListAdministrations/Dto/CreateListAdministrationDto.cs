namespace Coolbuh.Core.UseCases.Handlers.ListAdministrations.Dto
{
    /// <summary>
    /// DTO создания "Администрации"
    /// </summary>
    public class CreateListAdministrationDto
    {
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
    }
}
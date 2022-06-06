namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Справочник "Администрации"
    /// </summary>
    public class ListAdministration
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

        /// <inheritdoc cref="ListPosition"/>
        public virtual ListPosition Position { get; set; }
    }
}
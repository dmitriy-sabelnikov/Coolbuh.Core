namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Dto
{
    /// <summary>
    /// DTO "Типы дополнительных выплат"
    /// </summary>
    public class ListAdditionalPaymentTypeDto
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

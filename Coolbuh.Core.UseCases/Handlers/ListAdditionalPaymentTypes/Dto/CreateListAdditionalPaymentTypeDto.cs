namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Dto
{
    /// <summary>
    /// DTO создания "Типы дополнительных выплат"
    /// </summary>
    public class CreateListAdditionalPaymentTypeDto
    {
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

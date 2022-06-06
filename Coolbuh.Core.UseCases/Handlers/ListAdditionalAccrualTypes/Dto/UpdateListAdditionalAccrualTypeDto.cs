namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Dto
{
    /// <summary>
    /// DTO обновления "Типы дополнительных начислений"
    /// </summary>
    public class UpdateListAdditionalAccrualTypeDto
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

        /// <summary>
        /// Участвует в расчете
        /// </summary>
        public bool IsCalculate { get; set; }
    }
}

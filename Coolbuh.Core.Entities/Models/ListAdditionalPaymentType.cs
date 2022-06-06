using System.Collections.Generic;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Справочник "Типы дополнительных выплат" 
    /// </summary>
    public class ListAdditionalPaymentType
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
        /// Список дополнительных выплат
        /// </summary>
        public virtual List<AdditionalPayment> AdditionalPayments { get; set; }
    }
}

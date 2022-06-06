using System.Collections.Generic;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Справочник "Типы дополнительных начислений"
    /// </summary>
    public class ListAdditionalAccrualType
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
        /// Флаги
        /// </summary>
        public int Flags { get; set; }

        /// <summary>
        /// Список дополнительных начислений
        /// </summary>
        public virtual List<AdditionalAccrual> AdditionalAccruals { get; set; }
    }
}

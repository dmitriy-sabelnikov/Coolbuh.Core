using System.Collections.Generic;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Справочник "Типы статусов карточки"
    /// </summary>
    public class ListCardStatusType
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
        /// Список статусов карточки работника
        /// </summary>
        public virtual List<EmployeeCardStatus> EmployeeCardStatuses { get; set; }
    }
}
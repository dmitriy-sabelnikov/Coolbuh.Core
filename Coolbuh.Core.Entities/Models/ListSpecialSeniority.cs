using System.Collections.Generic;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Справочник "Спецстажи"
    /// </summary>
    public class ListSpecialSeniority
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
        /// Код основания
        /// </summary>
        public string ReasonCode { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список спецстажей
        /// </summary>
        public virtual List<EmployeeSpecialSeniority> EmployeeSpecialSeniorities { get; set; }
    }
}

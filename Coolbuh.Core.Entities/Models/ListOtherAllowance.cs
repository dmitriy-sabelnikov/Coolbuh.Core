using System.Collections.Generic;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Справочник "Другие надбавки"
    /// </summary>
    public class ListOtherAllowance
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
        /// Процент
        /// </summary>
        public decimal Percent { get; set; }

        /// <summary>
        /// Флаги
        /// </summary>
        public int Flags { get; set; }

        /// <summary>
        /// Список зарплат
        /// </summary>
        public virtual List<Salary> Salaries { get; set; }
    }
}

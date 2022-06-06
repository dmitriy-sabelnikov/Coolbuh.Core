using System.Collections.Generic;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Справочник "Надбавки за классность"
    /// </summary>
    public class ListGradeAllowance
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
        /// Условие применения. Классность
        /// </summary>
        public int? Grade { get; set; }

        /// <summary>
        /// Условие применения. Идентификатор подразделения
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Флаги
        /// </summary>
        public int Flags { get; set; }

        /// <inheritdoc cref="ListDepartment"/>
        public virtual ListDepartment Department { get; set; }

        /// <summary>
        /// Список зарплат
        /// </summary>
        public virtual List<Salary> Salaries { get; set; }
    }
}

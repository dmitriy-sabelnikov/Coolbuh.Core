using System.Collections.Generic;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Справочник "Подразделения"
    /// </summary>
    public class ListDepartment
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
        /// Список надбавок за классность
        /// </summary>
        public virtual List<ListGradeAllowance> GradeAllowances { get; set; }

        /// <summary>
        /// Список отпусков
        /// </summary>
        public virtual List<Vocation> Vocations { get; set; }

        /// <summary>
        /// Список больничных листов
        /// </summary>
        public virtual List<SickList> SickLists { get; set; }

        /// <summary>
        /// Список договоров ГПХ
        /// </summary>
        public virtual List<CivilLawContract> CivilLawContracts { get; set; }

        /// <summary>
        /// Список дополнительных начислений
        /// </summary>
        public virtual List<AdditionalAccrual> AdditionalAccruals { get; set; }

        /// <summary>
        /// Список зарплат
        /// </summary>
        public virtual List<Salary> Salaries { get; set; }
    }
}

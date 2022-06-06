using System;
using System.Collections.Generic;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Каталог объединенной ведомости
    /// </summary>
    public class ConsolidateReportCatalog
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Квартал
        /// </summary>
        public int Quarter { get; set; }

        /// <summary>
        /// Год
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата расчета
        /// </summary>
        public DateTime? CalculateDate { get; set; }

        /// <summary>
        /// Флаги
        /// </summary>
        public int Flags { get; set; }

        /// <summary>
        /// Список приложения 1
        /// </summary>
        public virtual List<ConsolidateReportAppendix1> ConsolidateReportAppendix1s { get; set; }

        /// <summary>
        /// Список приложения 4
        /// </summary>
        public virtual List<ConsolidateReportAppendix4> ConsolidateReportAppendix4s { get; set; }

        /// <summary>
        /// Список приложения 6
        /// </summary>
        public virtual List<ConsolidateReportAppendix6> ConsolidateReportAppendix6s { get; set; }
    }
}
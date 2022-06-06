using System;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Приложение 6. Ведомость о наличии оснований для учета стажа отдельным категориям лиц в соответствии с законодательством
    /// </summary>
    public class ConsolidateReportAppendix6
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор каталога объединенной ведомости
        /// </summary>
        public int ConsolidateReportCatalogId { get; set; }

        /// <summary>
        /// Отчетный период
        /// </summary>
        public DateTime AccountingPeriod { get; set; }

        /// <summary>
        /// Гражданство Украины
        /// </summary>
        public bool IsUkraineNationality { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string TaxIdentificationNumber { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Код основания
        /// </summary>
        public string ReasonCode { get; set; }

        /// <summary>
        /// Начало периода
        /// </summary>
        public int PeriodStartDay { get; set; }

        /// <summary>
        /// Конец периода
        /// </summary>
        public int PeriodStopDay { get; set; }

        /// <summary>
        /// Дни
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// Часы
        /// </summary>
        public int Hours { get; set; }

        /// <summary>
        /// Минуты
        /// </summary>
        public int Minutes { get; set; }

        /// <summary>
        /// Норма длительности работы для ее зачисления за полный месяц спецстажа, дни
        /// </summary>
        public int DayRate { get; set; }

        /// <summary>
        /// Норма длительности работы для ее зачисления за полный месяц спецстажа, часы
        /// </summary>
        public int HourRate { get; set; }

        /// <summary>
        /// Норма длительности работы для ее зачисления за полный месяц спецстажа, минуты
        /// </summary>
        public int MinuteRate { get; set; }

        /// <summary>
        /// Признак сезона
        /// </summary>
        public int SeasonSign { get; set; }
    }
}

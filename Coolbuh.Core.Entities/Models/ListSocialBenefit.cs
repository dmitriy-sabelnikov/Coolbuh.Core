using System;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Справочник "Социальные льготы"
    /// </summary>
    public class ListSocialBenefit
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Период. Начало
        /// </summary>
        public DateTime? PeriodBegin { get; set; }

        /// <summary>
        /// Период. Конец
        /// </summary>
        public DateTime? PeriodEnd { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Sum { get; set; }

        /// <summary>
        /// Ограничение социальной льготы
        /// </summary>
        public decimal LimitSum { get; set; }
    }
}

﻿namespace Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto
{
    /// <summary>
    /// DTO обновления "Надбавки за классность"
    /// </summary>
    public class UpdateListGradeAllowanceDto
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
        /// Флаг применения надбавки
        /// </summary>
        public bool UseAllowance { get; set; }
    }
}

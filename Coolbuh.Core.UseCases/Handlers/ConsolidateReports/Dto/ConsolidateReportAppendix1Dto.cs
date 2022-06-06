using Coolbuh.Core.Entities.Enums;
using System;

namespace Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto
{
    /// <summary>
    /// DTO "Приложение 1"
    /// </summary>
    public class ConsolidateReportAppendix1Dto
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
        /// Пол
        /// </summary>
        public EmployeeCardSex Sex { get; set; }

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
        /// Код категории
        /// </summary>
        public int CategoryCode { get; set; }

        /// <summary>
        /// Код тип начислений
        /// </summary>
        public int AccrualTypeCode { get; set; }

        /// <summary>
        /// Месяц, за который проводится начисление
        /// </summary>
        public int AccrualMonth { get; set; }

        /// <summary>
        /// Год, за который проводится начисление
        /// </summary>
        public int AccrualYear { get; set; }

        /// <summary>
        /// Количество календарных дней временной нетрудоспособности
        /// </summary>
        public int TemporaryDisabilityDays { get; set; }

        /// <summary>
        /// Количество календарных дней без сохранения зарплаты
        /// </summary>
        public int WithoutSalaryDays { get; set; }

        /// <summary>
        /// Количество дней пребывания в трудовых отношениях
        /// </summary>
        public int EmploymentDays { get; set; }

        /// <summary>
        /// Количество календарных дней отпуска в связи с беременностью и родами
        /// </summary>
        public int MaternityLeaveDays { get; set; }

        /// <summary>
        /// Общая сумма начисленной зарплаты/дохода (всего с начала отчетного месяца)
        /// </summary>
        public decimal AccrualTotalSum { get; set; }

        /// <summary>
        /// Cумма начисленной зарплаты/дохода в границах макс. величины, на которую начисляется взнос
        /// </summary>
        public decimal MaxAccrualTotalSum { get; set; }

        /// <summary>
        /// Сумма разницы между размером минимальной зарплаты и фактически начисленной зарплатой
        /// </summary>
        public decimal DifferenceSum { get; set; }

        /// <summary>
        /// Cумма удержанного единого взноса
        /// </summary>
        public decimal WithholdingUniformPaymentSum { get; set; }

        /// <summary>
        /// Cумма начисленного единого взноса
        /// </summary>
        public decimal AccrualUniformPaymentSum { get; set; }

        /// <summary>
        /// Признак наличия трудовой книжки
        /// </summary>
        public bool IsExistWorkBook { get; set; }

        /// <summary>
        /// Признак наличия спецстажа
        /// </summary>
        public bool IsSpecialSeniority { get; set; }

        /// <summary>
        /// Признак неполного рабочего времени
        /// </summary>
        public bool IsPartTimeWork { get; set; }

        /// <summary>
        /// Признак нового рабочего места
        /// </summary>
        public bool IsNewWorkplace { get; set; }
    }
}

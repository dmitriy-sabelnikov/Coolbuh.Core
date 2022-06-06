using System;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Приложение 4. Ведомость о суммах начисленного дохода, удержанного и уплаченного налога на доходы физ. лиц и военного сбора
    /// </summary>
    public class ConsolidateReportAppendix4
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
        /// Код ЕГРПОУ
        /// </summary>
        public int FirmUSREOU { get; set; }

        /// <summary>
        /// Тип организации
        /// </summary>
        public int FirmType { get; set; }

        /// <summary>
        /// Отчетный период
        /// </summary>
        public DateTime AccountingPeriod { get; set; }

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
        /// ИНН
        /// </summary>
        public string TaxIdentificationNumber { get; set; }

        /// <summary>
        /// Дата принятия на работу
        /// </summary>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Дата увольнения с работы
        /// </summary>
        public DateTime DismissalDate { get; set; }

        /// <summary>
        /// Признак налоговой социальной льготы
        /// </summary>
        public int TaxReliefSign { get; set; }

        /// <summary>
        /// Сумма начисленного дохода
        /// </summary>
        public decimal AccrualIncomeSum { get; set; }

        /// <summary>
        /// Сумма выплаченного дохода
        /// </summary>
        public decimal PaidIncomeSum { get; set; }

        /// <summary>
        /// Сумма удержанного налога, начисленного
        /// </summary>
        public decimal AccrualTaxSum { get; set; }

        /// <summary>
        /// Сумма удержанного налога, перечисленного
        /// </summary
        public decimal TransferTaxSum { get; set; }

        /// <summary>
        /// Признак дохода
        /// </summary>
        public int IncomeSign { get; set; }

        /// <summary>
        /// Сумма военного сбора, начисленного
        /// </summary>
        public decimal AccrualWarTaxSum { get; set; }

        /// <summary>
        /// Сумма военного сбора, перечисленного
        /// </summary>
        public decimal TransferWarTaxSum { get; set; }

        /// <inheritdoc cref="Models.ConsolidateReportCatalog"/>
        public virtual ConsolidateReportCatalog ConsolidateReportCatalog { get; set; }
    }
}

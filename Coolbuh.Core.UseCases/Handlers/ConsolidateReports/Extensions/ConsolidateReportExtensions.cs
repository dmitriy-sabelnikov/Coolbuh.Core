using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Extensions
{
    /// <summary>
    /// Методы расширения каталога объединенной ведомости
    /// </summary>
    public static class ConsolidateReportExtensions
    {
        /// <summary>
        /// Маппинг каталога объединенной ведомости
        /// </summary>
        /// <param name="dto">DTO создания "Каталог объединенной ведомости"</param>
        /// <returns>Каталог объединенной ведомости</returns>
        public static ConsolidateReportCatalog MapConsolidateReportCatalog(this CreateConsolidateReportCatalogDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new ConsolidateReportCatalog
            {
                Quarter = dto.Quarter,
                Year = dto.Year,
                Number = dto.Number,
                Name = dto.Name,
                Flags = GetFlags(dto.IsCalculate, dto.IsAskAboutCalculate)
            };
        }

        /// <summary>
        /// Маппинг каталога объединенной ведомости
        /// </summary>
        /// <param name="dto">DTO обновления "Каталог объединенной ведомости"</param>
        /// <returns>Каталог объединенной ведомости</returns>
        public static ConsolidateReportCatalog MapConsolidateReportCatalog(this UpdateConsolidateReportCatalogDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new ConsolidateReportCatalog
            {
                Id = dto.Id,
                Number = dto.Number,
                Name = dto.Name,
                Flags = GetFlags(dto.IsCalculate, dto.IsAskAboutCalculate)
            };
        }

        /// <summary>
        /// Маппинг каталога объединенной ведомости
        /// </summary>
        /// <param name="consolidateReportCatalog">DTO "Каталог объединенной ведомости"</param>
        /// <returns>Каталог объединенной ведомости</returns>
        public static ConsolidateReportCatalogDto MapConsolidateReportCatalogDto(this ConsolidateReportCatalog consolidateReportCatalog)
        {
            if (consolidateReportCatalog == null) throw new ArgumentNullException(nameof(consolidateReportCatalog));

            return new ConsolidateReportCatalogDto
            {
                Id = consolidateReportCatalog.Id,
                Quarter = consolidateReportCatalog.Quarter,
                Year = consolidateReportCatalog.Year,
                Number = consolidateReportCatalog.Number,
                Name = consolidateReportCatalog.Name,
                CalculateDate = consolidateReportCatalog.CalculateDate,
                IsAskAboutCalculate = (consolidateReportCatalog.Flags & (int)ConsolidateReportCatalogActions.IsAskAboutCalculate) > 0,
                IsCalculate = (consolidateReportCatalog.Flags & (int)ConsolidateReportCatalogActions.IsCalculate) > 0,
                IsNoCalculate = (consolidateReportCatalog.Flags & (int)ConsolidateReportCatalogActions.IsNoCalculate) > 0
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Каталог объединенной ведомости"
        /// </summary>
        /// <param name="consolidateReportCatalogs">Запрос последовательности "Каталог объединенной ведомости"</param>
        /// <returns>Запрос последовательности DTO "Каталог объединенной ведомости"</returns>
        public static IQueryable<ConsolidateReportCatalogDto> SelectConsolidateReportCatalogDtos(
            this IQueryable<ConsolidateReportCatalog> consolidateReportCatalogs)
        {
            return consolidateReportCatalogs.Select(consolidateReportCatalog => new ConsolidateReportCatalogDto
            {
                Id = consolidateReportCatalog.Id,
                Quarter = consolidateReportCatalog.Quarter,
                Year = consolidateReportCatalog.Year,
                Number = consolidateReportCatalog.Number,
                Name = consolidateReportCatalog.Name,
                CalculateDate = consolidateReportCatalog.CalculateDate,
                IsAskAboutCalculate = (consolidateReportCatalog.Flags & (int)ConsolidateReportCatalogActions.IsAskAboutCalculate) > 0,
                IsCalculate = (consolidateReportCatalog.Flags & (int)ConsolidateReportCatalogActions.IsCalculate) > 0,
                IsNoCalculate = (consolidateReportCatalog.Flags & (int)ConsolidateReportCatalogActions.IsNoCalculate) > 0
            });
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Приложение 1"
        /// </summary>
        /// <param name="consolidateReportAppendix1s">Запрос последовательности "Приложение 1"</param>
        /// <returns>Запрос последовательности DTO "Приложение 1"</returns>
        public static IQueryable<ConsolidateReportAppendix1Dto> SelectConsolidateReportAppendix1Dtos(
            this IQueryable<ConsolidateReportAppendix1> consolidateReportAppendix1s)
        {
            return consolidateReportAppendix1s.Select(appendix => new ConsolidateReportAppendix1Dto
            {
                Id = appendix.Id,
                ConsolidateReportCatalogId = appendix.ConsolidateReportCatalogId,
                AccountingPeriod = appendix.AccountingPeriod,
                IsUkraineNationality = appendix.IsUkraineNationality,
                Sex = appendix.Sex,
                TaxIdentificationNumber = appendix.TaxIdentificationNumber,
                FirstName = appendix.FirstName,
                MiddleName = appendix.MiddleName,
                LastName = appendix.LastName,
                CategoryCode = appendix.CategoryCode,
                AccrualTypeCode = appendix.AccrualTypeCode,
                AccrualMonth = appendix.AccrualMonth,
                AccrualYear = appendix.AccrualYear,
                TemporaryDisabilityDays = appendix.TemporaryDisabilityDays,
                WithoutSalaryDays = appendix.WithoutSalaryDays,
                EmploymentDays = appendix.EmploymentDays,
                MaternityLeaveDays = appendix.MaternityLeaveDays,
                AccrualTotalSum = appendix.AccrualTotalSum,
                MaxAccrualTotalSum = appendix.MaxAccrualTotalSum,
                DifferenceSum = appendix.DifferenceSum,
                WithholdingUniformPaymentSum = appendix.WithholdingUniformPaymentSum,
                AccrualUniformPaymentSum = appendix.AccrualUniformPaymentSum,
                IsExistWorkBook = appendix.IsExistWorkBook,
                IsSpecialSeniority = appendix.IsSpecialSeniority,
                IsPartTimeWork = appendix.IsPartTimeWork,
                IsNewWorkplace = appendix.IsNewWorkplace
            });
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Приложение 4"
        /// </summary>
        /// <param name="consolidateReportAppendix4s">Запрос последовательности "Приложение 4"</param>
        /// <returns>Запрос последовательности DTO "Приложение 4"</returns>
        public static IQueryable<ConsolidateReportAppendix4Dto> SelectConsolidateReportAppendix4Dtos(
            this IQueryable<ConsolidateReportAppendix4> consolidateReportAppendix4s)
        {
            return consolidateReportAppendix4s.Select(appendix => new ConsolidateReportAppendix4Dto
            {
                Id = appendix.Id,
                ConsolidateReportCatalogId = appendix.ConsolidateReportCatalogId,
                FirmUSREOU = appendix.FirmUSREOU,
                FirmType = appendix.FirmType,
                AccountingPeriod = appendix.AccountingPeriod,
                FirstName = appendix.FirstName,
                MiddleName = appendix.MiddleName,
                LastName = appendix.LastName,
                TaxIdentificationNumber = appendix.TaxIdentificationNumber,
                EntryDate = appendix.EntryDate,
                DismissalDate = appendix.DismissalDate,
                TaxReliefSign = appendix.TaxReliefSign,
                AccrualIncomeSum = appendix.AccrualIncomeSum,
                PaidIncomeSum = appendix.PaidIncomeSum,
                AccrualTaxSum = appendix.AccrualTaxSum,
                TransferTaxSum = appendix.TransferTaxSum,
                IncomeSign = appendix.IncomeSign,
                AccrualWarTaxSum = appendix.AccrualWarTaxSum,
                TransferWarTaxSum = appendix.TransferWarTaxSum
            });
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Приложение 6"
        /// </summary>
        /// <param name="consolidateReportAppendix6s">Запрос последовательности "Приложение 6"</param>
        /// <returns>Запрос последовательности DTO "Приложение 6"</returns>
        public static IQueryable<ConsolidateReportAppendix6Dto> SelectConsolidateReportAppendix6Dtos(
            this IQueryable<ConsolidateReportAppendix6> consolidateReportAppendix6s)
        {
            return consolidateReportAppendix6s.Select(appendix => new ConsolidateReportAppendix6Dto
            {
                Id = appendix.Id,
                ConsolidateReportCatalogId = appendix.ConsolidateReportCatalogId,
                AccountingPeriod = appendix.AccountingPeriod,
                IsUkraineNationality = appendix.IsUkraineNationality,
                TaxIdentificationNumber = appendix.TaxIdentificationNumber,
                FirstName = appendix.FirstName,
                MiddleName = appendix.MiddleName,
                LastName = appendix.LastName,
                ReasonCode = appendix.ReasonCode,
                PeriodStartDay = appendix.PeriodStartDay,
                PeriodStopDay = appendix.PeriodStopDay,
                Days = appendix.Days,
                Hours = appendix.Hours,
                Minutes = appendix.Minutes,
                DayRate = appendix.DayRate,
                HourRate = appendix.HourRate,
                MinuteRate = appendix.MinuteRate,
                SeasonSign = appendix.SeasonSign
            });
        }

        /// <summary>
        /// Получить флаги каталога объединенной ведомости
        /// </summary>
        /// <param name="isCalculate">Рассчитывать</param>
        /// <param name="isAskAboutCalculate">Спрашивать о расчете</param>
        /// <returns>Флаги</returns>
        private static int GetFlags(bool isCalculate, bool isAskAboutCalculate)
        {
            var flags = 0;
            if (isCalculate)
                flags += (int)ConsolidateReportCatalogActions.IsCalculate;
            else if (isAskAboutCalculate)
                flags += (int)ConsolidateReportCatalogActions.IsAskAboutCalculate;
            else
                flags += (int)ConsolidateReportCatalogActions.IsNoCalculate;

            return flags;
        }
    }
}
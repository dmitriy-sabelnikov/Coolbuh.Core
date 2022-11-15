using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Entities.Models;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IAccountingPeriodsService"/>
    public class AccountingPeriodsService : IAccountingPeriodsService
    {
        /// <inheritdoc/>
        public IEnumerable<AccountingPeriod> GetAccountingPeriods(DateTime periodStart, DateTime periodEnd,
            bool isAddItemAllYear)
        {
            var calendar = new List<AccountingPeriod>();
            for (var year = periodStart.Year; year <= periodEnd.Year; year++)
            {
                if (isAddItemAllYear)
                {
                    calendar.Add(new AccountingPeriod
                    {
                        Year = year,
                        Month = 0,
                        Caption = $"Рік {year}"
                    });
                }

                var monthStart = year == periodStart.Year ? periodStart.Month : 1;
                var monthEnd = year == periodEnd.Year ? periodEnd.Month : 12;

                for (var month = monthStart; month <= monthEnd; month++)
                {
                    calendar.Add(new AccountingPeriod
                    {
                        Year = year,
                        Month = month,
                        Caption = $"{GetMonthName(month, WordCase.Nominative)} {year}"
                    });
                }
            }

            return calendar;
        }

        /// <summary>
        /// Получить наименование месяца 
        /// </summary>
        /// <param name="month">Номер месяца</param>
        /// <param name="wordCase">Падеж</param>
        /// <returns>Наименование месяца</returns>
        private static string GetMonthName(int month, WordCase wordCase)
        {
            return month switch
            {
                1 => GetWordCaseJanuary(wordCase),
                2 => GetWordCaseFebruary(wordCase),
                3 => GetWordCaseMarch(wordCase),
                4 => GetWordCaseApril(wordCase),
                5 => GetWordCaseMay(wordCase),
                6 => GetWordCaseJune(wordCase),
                7 => GetWordCaseJuly(wordCase),
                8 => GetWordCaseAugust(wordCase),
                9 => GetWordCaseSeptember(wordCase),
                10 => GetWordCaseOctober(wordCase),
                11 => GetWordCaseNovember(wordCase),
                12 => GetWordCaseDecember(wordCase),
                _ => throw new ArgumentOutOfRangeException(nameof(month), month, null)
            };
        }

        /// <summary>
        /// Получить наименование января месяца по падежам 
        /// </summary>
        /// <param name="wordCase">Падеж</param>
        /// <returns>Наименование месяца</returns>
        private static string GetWordCaseJanuary(WordCase wordCase)
        {
            return wordCase switch
            {
                WordCase.Nominative => "Січень",
                WordCase.Genetive => "Січня",
                WordCase.Dative => "Січню",
                WordCase.Accusative => "Січень",
                WordCase.Instrumental => "Січнем",
                WordCase.Prepositional => "Січню",
                _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
            };
        }

        /// <summary>
        /// Получить наименование февраля месяца по падежам 
        /// </summary>
        /// <param name="wordCase">Падеж</param>
        /// <returns>Наименование месяца</returns>
        private static string GetWordCaseFebruary(WordCase wordCase)
        {
            return wordCase switch
            {
                WordCase.Nominative => "Лютий",
                WordCase.Genetive => "Лютого",
                WordCase.Dative => "Лютому",
                WordCase.Accusative => "Лютий",
                WordCase.Instrumental => "Лютим",
                WordCase.Prepositional => "Лютому",
                _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
            };
        }

        /// <summary>
        /// Получить наименование марта месяца по падежам 
        /// </summary>
        /// <param name="wordCase">Падеж</param>
        /// <returns>Наименование месяца</returns>
        private static string GetWordCaseMarch(WordCase wordCase)
        {
            return wordCase switch
            {
                WordCase.Nominative => "Березень",
                WordCase.Genetive => "Березня",
                WordCase.Dative => "Березню",
                WordCase.Accusative => "Березень",
                WordCase.Instrumental => "Березнем",
                WordCase.Prepositional => "Березню",
                _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
            };
        }

        /// <summary>
        /// Получить наименование февраля апреля по падежам 
        /// </summary>
        /// <param name="wordCase">Падеж</param>
        /// <returns>Наименование месяца</returns>
        private static string GetWordCaseApril(WordCase wordCase)
        {
            return wordCase switch
            {
                WordCase.Nominative => "Квітень",
                WordCase.Genetive => "Квітня",
                WordCase.Dative => "Квітню",
                WordCase.Accusative => "Квітень",
                WordCase.Instrumental => "Квітнем",
                WordCase.Prepositional => "Квітню",
                _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
            };
        }

        /// <summary>
        /// Получить наименование мая месяца по падежам 
        /// </summary>
        /// <param name="wordCase">Падеж</param>
        /// <returns>Наименование месяца</returns>
        private static string GetWordCaseMay(WordCase wordCase)
        {
            return wordCase switch
            {
                WordCase.Nominative => "Травень",
                WordCase.Genetive => "Травня",
                WordCase.Dative => "Травню",
                WordCase.Accusative => "Травень",
                WordCase.Instrumental => "Травнем",
                WordCase.Prepositional => "Травню",
                _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
            };
        }

        /// <summary>
        /// Получить наименование июня месяца по падежам 
        /// </summary>
        /// <param name="wordCase">Падеж</param>
        /// <returns>Наименование месяца</returns>
        private static string GetWordCaseJune(WordCase wordCase)
        {
            return wordCase switch
            {
                WordCase.Nominative => "Червень",
                WordCase.Genetive => "Червня",
                WordCase.Dative => "Червню",
                WordCase.Accusative => "Червень",
                WordCase.Instrumental => "Червнем",
                WordCase.Prepositional => "Червню",
                _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
            };
        }

        /// <summary>
        /// Получить наименование июля месяца по падежам 
        /// </summary>
        /// <param name="wordCase">Падеж</param>
        /// <returns>Наименование месяца</returns>
        private static string GetWordCaseJuly(WordCase wordCase)
        {
            return wordCase switch
            {
                WordCase.Nominative => "Липень",
                WordCase.Genetive => "Липня",
                WordCase.Dative => "Липню",
                WordCase.Accusative => "Липень",
                WordCase.Instrumental => "Липнем",
                WordCase.Prepositional => "Липню",
                _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
            };
        }

        /// <summary>
        /// Получить наименование августа месяца по падежам 
        /// </summary>
        /// <param name="wordCase">Падеж</param>
        /// <returns>Наименование месяца</returns>
        private static string GetWordCaseAugust(WordCase wordCase)
        {
            return wordCase switch
            {
                WordCase.Nominative => "Серпень",
                WordCase.Genetive => "Серпня",
                WordCase.Dative => "Серпню",
                WordCase.Accusative => "Серпень",
                WordCase.Instrumental => "Серпнем",
                WordCase.Prepositional => "Серпні",
                _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
            };
        }

        /// <summary>
        /// Получить наименование сентября месяца по падежам 
        /// </summary>
        /// <param name="wordCase">Падеж</param>
        /// <returns>Наименование месяца</returns>
        private static string GetWordCaseSeptember(WordCase wordCase)
        {
            return wordCase switch
            {
                WordCase.Nominative => "Вересень",
                WordCase.Genetive => "Вересня",
                WordCase.Dative => "Вересню",
                WordCase.Accusative => "Вересень",
                WordCase.Instrumental => "Вереснем",
                WordCase.Prepositional => "Вересні",
                _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
            };
        }

        /// <summary>
        /// Получить наименование октября месяца по падежам 
        /// </summary>
        /// <param name="wordCase">Падеж</param>
        /// <returns>Наименование месяца</returns>
        private static string GetWordCaseOctober(WordCase wordCase)
        {
            return wordCase switch
            {
                WordCase.Nominative => "Жовтень",
                WordCase.Genetive => "Жовтня",
                WordCase.Dative => "Жовтню",
                WordCase.Accusative => "Жовтень",
                WordCase.Instrumental => "Жовтнем",
                WordCase.Prepositional => "Жовтні",
                _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
            };
        }

        /// <summary>
        /// Получить наименование ноября месяца по падежам 
        /// </summary>
        /// <param name="wordCase">Падеж</param>
        /// <returns>Наименование месяца</returns>
        private static string GetWordCaseNovember(WordCase wordCase)
        {
            return wordCase switch
            {
                WordCase.Nominative => "Листопад",
                WordCase.Genetive => "Листопада",
                WordCase.Dative => "Листопаду",
                WordCase.Accusative => "Листопад",
                WordCase.Instrumental => "Листопадом",
                WordCase.Prepositional => "Листопаде",
                _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
            };
        }

        /// <summary>
        /// Получить наименование декабря месяца по падежам 
        /// </summary>
        /// <param name="wordCase">Падеж</param>
        /// <returns>Наименование месяца</returns>
        private static string GetWordCaseDecember(WordCase wordCase)
        {
            return wordCase switch
            {
                WordCase.Nominative => "Грудень",
                WordCase.Genetive => "Грудня",
                WordCase.Dative => "Грудню",
                WordCase.Accusative => "Грудень",
                WordCase.Instrumental => "Груднем",
                WordCase.Prepositional => "Грудні",
                _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
            };
        }
    }
}

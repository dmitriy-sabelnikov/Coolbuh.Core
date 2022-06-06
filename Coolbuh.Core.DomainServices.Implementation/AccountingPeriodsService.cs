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
                1 => wordCase switch
                {
                    WordCase.Nominative => "Січень",
                    WordCase.Genetive => "Січня",
                    WordCase.Dative => "Січню",
                    WordCase.Accusative => "Січень",
                    WordCase.Instrumental => "Січнем",
                    WordCase.Prepositional => "Січню",
                    _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
                },
                2 => wordCase switch
                {
                    WordCase.Nominative => "Лютий",
                    WordCase.Genetive => "Лютого",
                    WordCase.Dative => "Лютому",
                    WordCase.Accusative => "Лютий",
                    WordCase.Instrumental => "Лютим",
                    WordCase.Prepositional => "Лютому",
                    _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
                },
                3 => wordCase switch
                {
                    WordCase.Nominative => "Березень",
                    WordCase.Genetive => "Березня",
                    WordCase.Dative => "Березню",
                    WordCase.Accusative => "Березень",
                    WordCase.Instrumental => "Березнем",
                    WordCase.Prepositional => "Березню",
                    _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
                },
                4 => wordCase switch
                {
                    WordCase.Nominative => "Квітень",
                    WordCase.Genetive => "Квітня",
                    WordCase.Dative => "Квітню",
                    WordCase.Accusative => "Квітень",
                    WordCase.Instrumental => "Квітнем",
                    WordCase.Prepositional => "Квітню",
                    _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
                },
                5 => wordCase switch
                {
                    WordCase.Nominative => "Травень",
                    WordCase.Genetive => "Травня",
                    WordCase.Dative => "Травню",
                    WordCase.Accusative => "Травень",
                    WordCase.Instrumental => "Травнем",
                    WordCase.Prepositional => "Травню",
                    _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
                },
                6 => wordCase switch
                {
                    WordCase.Nominative => "Червень",
                    WordCase.Genetive => "Червня",
                    WordCase.Dative => "Червню",
                    WordCase.Accusative => "Червень",
                    WordCase.Instrumental => "Червнем",
                    WordCase.Prepositional => "Червню",
                    _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
                },
                7 => wordCase switch
                {
                    WordCase.Nominative => "Липень",
                    WordCase.Genetive => "Липня",
                    WordCase.Dative => "Липню",
                    WordCase.Accusative => "Липень",
                    WordCase.Instrumental => "Липнем",
                    WordCase.Prepositional => "Липню",
                    _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
                },
                8 => wordCase switch
                {
                    WordCase.Nominative => "Серпень",
                    WordCase.Genetive => "Серпня",
                    WordCase.Dative => "Серпню",
                    WordCase.Accusative => "Серпень",
                    WordCase.Instrumental => "Серпнем",
                    WordCase.Prepositional => "Серпні",
                    _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
                },
                9 => wordCase switch
                {
                    WordCase.Nominative => "Вересень",
                    WordCase.Genetive => "Вересня",
                    WordCase.Dative => "Вересню",
                    WordCase.Accusative => "Вересень",
                    WordCase.Instrumental => "Вереснем",
                    WordCase.Prepositional => "Вересні",
                    _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
                },
                10 => wordCase switch
                {
                    WordCase.Nominative => "Жовтень",
                    WordCase.Genetive => "Жовтня",
                    WordCase.Dative => "Жовтню",
                    WordCase.Accusative => "Жовтень",
                    WordCase.Instrumental => "Жовтнем",
                    WordCase.Prepositional => "Жовтні",
                    _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
                },
                11 => wordCase switch
                {
                    WordCase.Nominative => "Листопад",
                    WordCase.Genetive => "Листопада",
                    WordCase.Dative => "Листопаду",
                    WordCase.Accusative => "Листопад",
                    WordCase.Instrumental => "Листопадом",
                    WordCase.Prepositional => "Листопаде",
                    _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
                },
                12 => wordCase switch
                {
                    WordCase.Nominative => "Грудень",
                    WordCase.Genetive => "Грудня",
                    WordCase.Dative => "Грудню",
                    WordCase.Accusative => "Грудень",
                    WordCase.Instrumental => "Груднем",
                    WordCase.Prepositional => "Грудні",
                    _ => throw new ArgumentOutOfRangeException(nameof(wordCase), wordCase, null)
                },
                _ => throw new ArgumentOutOfRangeException(nameof(month), month, null)
            };
        }
    }
}

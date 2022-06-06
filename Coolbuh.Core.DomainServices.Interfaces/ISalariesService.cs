using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис "Заработные платы"
    /// </summary>
    public interface ISalariesService
    {
        /// <summary>
        /// Валидация заработной платы
        /// </summary>
        /// <param name="salary">Заработная плата</param>
        void ValidationEntity(Salary salary);

        /// <summary>
        /// Расчет надбавки за пенсию
        /// </summary>
        /// <param name="sum">Сумма зарплаты</param>
        /// <param name="percent">Процент надбавки</param>
        /// <returns>Сумма надбавки за пенсию</returns>
        decimal CalculatePensionAllowanceSum(decimal sum, decimal percent);

        /// <summary>
        /// Расчет надбавки за классность
        /// </summary>
        /// <param name="sum">Сумма зарплаты</param>
        /// <param name="percent">Процент надбавки</param>
        /// <returns>Сумма надбавки за классность</returns>
        decimal CalculateGradeAllowanceSum(decimal sum, decimal percent);

        /// <summary>
        /// Расчет другой надбавки
        /// </summary>
        /// <param name="sum">Сумма зарплаты</param>
        /// <param name="percent">Процент надбавки</param>
        /// <returns>Сумма другой надбавки</returns>
        decimal CalculateOtherAllowanceSum(decimal sum, decimal percent);

        /// <summary>
        /// Расчет итоговой суммы зарплаты
        /// </summary>
        /// <param name="sum">Сумма зарплаты</param>
        /// <param name="pensionAllowanceSum">Сумма надбавки за пенсию</param>
        /// <param name="gradeAllowanceSum">Сумма надбавки за классность</param>
        /// <param name="otherAllowanceSum">Сумма другой надбавки</param>
        /// <returns>Итоговая сумма зарплаты</returns>
        decimal CalculateSalaryResultSum(decimal sum, decimal pensionAllowanceSum,
            decimal gradeAllowanceSum, decimal otherAllowanceSum);

        ///// <summary>
        ///// Расчет заработной платы
        ///// </summary>
        ///// <param name="salary">Заработная плата</param>
        ///// <param name="pensionAllowance">Надбавка за пенсию</param>
        ///// <param name="gradeAllowance">Надбавка за классность</param>
        ///// <param name="otherAllowance">Другая надбавка</param>
        //public void Calculate(Salary salary, ListPensionAllowance pensionAllowance, ListGradeAllowance gradeAllowance,
        //    ListOtherAllowance otherAllowance);
    }
}

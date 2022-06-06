namespace Coolbuh.Core.Entities.Constants
{
    /// <summary>
    /// Константы карточки работника
    /// </summary>
    public static class EmployeeCardConstants
    {
        /// <summary>
        /// Максимальная длина имени
        /// </summary>
        public static int FirstNameLength => 250;

        /// <summary>
        /// Максимальная длина отчества
        /// </summary>
        public static int MiddleNameLength => 250;

        /// <summary>
        /// Максимальная длина фамилии
        /// </summary>
        public static int LastNameLength => 250;

        /// <summary>
        /// Максимальная длина ИНН
        /// </summary>
        public static int TaxIdentificationNumberLength => 50;
    }
}

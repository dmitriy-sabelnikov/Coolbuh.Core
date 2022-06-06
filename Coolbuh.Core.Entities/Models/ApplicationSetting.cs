using Coolbuh.Core.Entities.Enums;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Параметры приложения
    /// </summary>
    public class ApplicationSetting
    {
        /// <summary>
        /// Тип параметра
        /// </summary>
        public ApplicationSettingType Type { get; set; }

        /// <summary>
        /// Числовое значение
        /// </summary>
        public int? DigitValue { get; set; }

        /// <summary>
        /// Строковое значение
        /// </summary>
        public string StringValue { get; set; }
    }
}

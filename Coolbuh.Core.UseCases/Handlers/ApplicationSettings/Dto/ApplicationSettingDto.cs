namespace Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Dto
{
    /// <summary>
    /// DTO "Параметры приложения"
    /// </summary>
    public class ApplicationSettingDto
    {
        /// <summary>
        /// Наименование предприятия
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// ЕГРПОУ предприятия
        /// </summary>
        public string CompanyUSREOU { get; set; }

        /// <summary>
        /// Количество лет отображения периодов
        /// </summary>
        public int? AccountingYear { get; set; }
    }
}

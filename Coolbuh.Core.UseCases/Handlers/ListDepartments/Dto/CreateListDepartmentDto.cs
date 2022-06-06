namespace Coolbuh.Core.UseCases.Handlers.ListDepartments.Dto
{
    /// <summary>
    /// DTO создания "Подразделения"
    /// </summary>
    public class CreateListDepartmentDto
    {
        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
    }
}

namespace Coolbuh.Core.UseCases.Handlers.ListDepartments.Dto
{
    /// <summary>
    /// DTO "Подразделения"
    /// </summary>
    public class ListDepartmentDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

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

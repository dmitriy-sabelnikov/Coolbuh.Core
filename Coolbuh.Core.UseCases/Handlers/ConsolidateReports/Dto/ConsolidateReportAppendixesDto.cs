using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto
{
    /// <summary>
    /// DTO "Все приложения объединенной ведомость"
    /// </summary>
    public class ConsolidateReportAppendixesDto
    {
        /// <summary>
        /// Приложения 1 
        /// </summary>
        public List<ConsolidateReportAppendix1Dto> ConsolidateReportAppendixes1 { get; set; }
        /// <summary>
        /// Приложения 4 
        /// </summary>
        public List<ConsolidateReportAppendix4Dto> ConsolidateReportAppendixes4 { get; set; }
        /// <summary>
        /// Приложения 6 
        /// </summary>
        public List<ConsolidateReportAppendix6Dto> ConsolidateReportAppendixes6 { get; set; }
    }
}

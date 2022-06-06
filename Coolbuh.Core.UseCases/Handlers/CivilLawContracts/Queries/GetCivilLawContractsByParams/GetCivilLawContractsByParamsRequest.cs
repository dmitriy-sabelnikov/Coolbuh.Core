using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Dto;
using MediatR;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Queries.GetCivilLawContractsByParams
{
    /// <summary>
    /// Объект запроса "Получить список договоров ГПХ"
    /// </summary>
    public class GetCivilLawContractsByParamsRequest : IRequest<List<CivilLawContractDto>>
    {
        /// <summary>
        /// Начало отчетного периода
        /// </summary>
        public DateTime StartPeriod { get; set; }

        /// <summary>
        /// Окончание отчетного периода
        /// </summary>
        public DateTime EndPeriod { get; set; }

        /// <summary>
        /// Идентификатор подразделения
        /// </summary>
        public int? DepartmentId { get; set; }
    }
}

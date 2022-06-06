using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Commands.UpdateCivilLawContract
{
    /// <summary>
    /// Объект команды "Обновить договор ГПХ"
    /// </summary>
    public class UpdateCivilLawContractRequest : IRequest<CivilLawContractDto>
    {
        ///<inheritdoc cref="UpdateCivilLawContractDto"/> 
        public UpdateCivilLawContractDto CivilLawContract { get; set; }
    }
}

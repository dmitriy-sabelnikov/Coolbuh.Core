using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Commands.DeleteCivilLawContract
{
    /// <summary>
    /// Объект команды "Удалить договор ГПХ"
    /// </summary>
    public class DeleteCivilLawContractRequest : IRequest<CivilLawContractDto>
    {
        ///<inheritdoc cref="DeleteCivilLawContractDto"/> 
        public DeleteCivilLawContractDto CivilLawContract { get; set; }
    }
}

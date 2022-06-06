using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Commands.CreateCivilLawContract
{
    /// <summary>
    /// Объект команды "Создать договор ГПХ"
    /// </summary>
    public class CreateCivilLawContractRequest : IRequest<CivilLawContractDto>
    {
        ///<inheritdoc cref="CreateCivilLawContractDto"/> 
        public CreateCivilLawContractDto CivilLawContract { get; set; }
    }
}

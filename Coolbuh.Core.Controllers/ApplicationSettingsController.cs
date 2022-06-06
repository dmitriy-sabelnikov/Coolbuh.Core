using Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Commands.ChangeApplicationSettings;
using Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Dto;
using Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Queries.GetApplicationSettings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Параметры приложения
    /// </summary>
    public class ApplicationSettingsController : ApiController
    {
        public ApplicationSettingsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить параметры приложения
        /// </summary>
        /// <response code="200">Параметры приложения</response>
        [HttpGet]
        public async Task<ApplicationSettingDto> Get()
        {
            return await _mediator.Send(new GetApplicationSettingsRequest());
        }

        /// <summary>
        /// Изменить параметры приложения
        /// </summary>
        /// <param name="applicationSetting">Параметры приложения для изменения</param>
        /// <returns>Измененные параметры приложения</returns>
        [HttpPost]
        public async Task<ApplicationSettingDto> Post([FromBody] ChangeApplicationSettingDto applicationSetting)
        {
            return await _mediator.Send(new ChangeApplicationSettingsRequest { ApplicationSetting = applicationSetting });
        }
    }
}

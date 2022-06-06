using Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Commands.ChangeApplicationSettings
{
    /// <summary>
    /// Объект команды "Изменить параметры приложения"
    /// </summary>
    public class ChangeApplicationSettingsRequest : IRequest<ApplicationSettingDto>
    {
        ///<inheritdoc cref="ChangeApplicationSettingDto"/>
        public ChangeApplicationSettingDto ApplicationSetting { get; set; }
    }
}

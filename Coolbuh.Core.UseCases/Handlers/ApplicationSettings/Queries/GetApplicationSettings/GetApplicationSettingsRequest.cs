using Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Queries.GetApplicationSettings
{
    /// <summary>
    /// Объект запроса "Получить параметры приложения"
    /// </summary>
    public class GetApplicationSettingsRequest : IRequest<ApplicationSettingDto>
    {
    }
}

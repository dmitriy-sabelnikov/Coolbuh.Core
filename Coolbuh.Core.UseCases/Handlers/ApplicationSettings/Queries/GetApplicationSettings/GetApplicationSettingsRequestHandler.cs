using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Dto;
using Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Queries.GetApplicationSettings
{
    /// <summary>
    /// Обработчик запроса "Получить параметры приложения"
    /// </summary>
    public class GetApplicationSettingsRequestHandler
        : IRequestHandler<GetApplicationSettingsRequest, ApplicationSettingDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetApplicationSettingsRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Параметры приложения"</returns>
        public async Task<ApplicationSettingDto> Handle(GetApplicationSettingsRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var applicationSettings =
                await _dbContext.ApplicationSettings.AsNoTracking().ToListAsync(cancellationToken);

            return applicationSettings.MapApplicationSettingDto();
        }
    }
}

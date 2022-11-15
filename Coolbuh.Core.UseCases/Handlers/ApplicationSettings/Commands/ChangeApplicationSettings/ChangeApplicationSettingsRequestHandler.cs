using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Dto;
using Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Commands.ChangeApplicationSettings
{
    /// <summary>
    /// Обработчик команды "Изменить параметры приложения"
    /// </summary>
    public class ChangeApplicationSettingsRequestHandler
        : IRequestHandler<ChangeApplicationSettingsRequest, ApplicationSettingDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public ChangeApplicationSettingsRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        public async Task<ApplicationSettingDto> Handle(ChangeApplicationSettingsRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.ApplicationSetting == null)
                throw new InvalidOperationException("request.ApplicationSetting is null");

            var applicationSettings =
                await _dbContext.ApplicationSettings.AsNoTracking().ToListAsync(cancellationToken);

            var changeApplicationSettings = request.ApplicationSetting.MapApplicationSettings();

            var deleteApplicationSettings = new List<ApplicationSetting>();
            var insertApplicationSettings = new List<ApplicationSetting>();
            var updateApplicationSettings = new List<ApplicationSetting>();

            applicationSettings.ForEach(setting =>
            {
                if (changeApplicationSettings.All(rec => rec.Type != setting.Type))
                    deleteApplicationSettings.Add(setting);
            });

            changeApplicationSettings.ForEach(setting =>
            {
                if (applicationSettings.All(rec => rec.Type != setting.Type))
                    insertApplicationSettings.Add(setting);
                if (applicationSettings.Any(rec => rec.Type == setting.Type))
                    updateApplicationSettings.Add(setting);
            });

            if (deleteApplicationSettings.Count > 0)
                _dbContext.ApplicationSettings.RemoveRange(deleteApplicationSettings);

            if (updateApplicationSettings.Count > 0)
                _dbContext.ApplicationSettings.UpdateRange(updateApplicationSettings);

            if (insertApplicationSettings.Count > 0)
                await _dbContext.ApplicationSettings.AddRangeAsync(insertApplicationSettings, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return changeApplicationSettings.MapApplicationSettingDto();
        }
    }
}

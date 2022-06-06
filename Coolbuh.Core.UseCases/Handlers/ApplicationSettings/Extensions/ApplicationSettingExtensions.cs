using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Dto;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ApplicationSettings.Extensions
{
    /// <summary>
    /// Методы расширения параметры приложения
    /// </summary>
    public static class ApplicationSettingExtensions
    {
        /// <summary>
        /// Маппинг списка "Параметры приложения"
        /// </summary>
        /// <param name="dto">DTO изменения "Параметры приложения"</param>
        /// <returns>Список "Параметры приложения"</returns>
        public static List<ApplicationSetting> MapApplicationSettings(this ChangeApplicationSettingDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            var result = new List<ApplicationSetting>();

            if (dto.AccountingYear.HasValue)
            {
                result.Add(new ApplicationSetting
                {
                    Type = ApplicationSettingType.AccountingYear,
                    DigitValue = dto.AccountingYear
                });
            }
            if (!string.IsNullOrEmpty(dto.CompanyName))
            {
                result.Add(new ApplicationSetting
                {
                    Type = ApplicationSettingType.CompanyName,
                    StringValue = dto.CompanyName
                });
            }
            if (!string.IsNullOrEmpty(dto.CompanyUSREOU))
            {
                result.Add(new ApplicationSetting
                {
                    Type = ApplicationSettingType.CompanyUSREOU,
                    StringValue = dto.CompanyUSREOU
                });
            }

            return result;
        }

        /// <summary>
        /// Маппинг DTO "Параметры приложения"
        /// </summary>
        /// <param name="applicationSettings">Список параметров приложения</param>
        /// <returns>DTO "Параметры приложения"</returns>
        public static ApplicationSettingDto MapApplicationSettingDto(
            this List<ApplicationSetting> applicationSettings)
        {
            if (applicationSettings == null) throw new NullReferenceException(nameof(applicationSettings));

            var applicationSettingsDto = new ApplicationSettingDto();
            foreach (var setting in applicationSettings)
            {
                switch (setting.Type)
                {
                    case ApplicationSettingType.AccountingYear:
                        applicationSettingsDto.AccountingYear = setting.DigitValue;
                        break;
                    case ApplicationSettingType.CompanyName:
                        applicationSettingsDto.CompanyName = setting.StringValue;
                        break;
                    case ApplicationSettingType.CompanyUSREOU:
                        applicationSettingsDto.CompanyUSREOU = setting.StringValue;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(applicationSettings), setting.Type, null);
                }
            }

            return applicationSettingsDto;
        }
    }
}

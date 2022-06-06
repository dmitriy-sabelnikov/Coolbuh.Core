using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace Coolbuh.Core.WebCore.DependencyInjection
{
    /// <summary>
    /// Swagger
    /// </summary>
    public static class SwaggerDIExtension
    {
        /// <summary>
        /// Добавить swagger
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Coolbuh API",
                    Description = "API бухгалтерской программы",
                    Contact = new OpenApiContact
                    {
                        Name = "Dmitriy Sabelnykov",
                        Email = "dmitriy.sabelnikov@gmail.com"
                    }
                });

                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    var xmlFile = $"{assembly.GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    if (File.Exists(xmlPath))
                        setup.IncludeXmlComments(xmlPath, true);
                }
            });
        }
    }
}

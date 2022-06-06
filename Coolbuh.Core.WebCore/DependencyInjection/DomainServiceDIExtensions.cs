using Coolbuh.Core.DomainServices.Implementation;
using Coolbuh.Core.DomainServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Coolbuh.Core.WebCore.DependencyInjection
{
    /// <summary>
    /// Внедрение зависимости доменных сервисов 
    /// </summary>
    public static class DomainServiceDIExtensions
    {
        /// <summary>
        /// Добавить зависимости доменных сервисов
        /// </summary>
        /// <param name="services"></param>
        public static void AddDomainServices(this IServiceCollection services)
        {
            var interfaceTypes = Assembly.GetAssembly(typeof(IListMinimumSalariesService))?.GetTypes()
                .Where(m => m.IsInterface)
                .ToList();

            if (interfaceTypes == null)
                return;

            var classTypes = Assembly.GetAssembly(typeof(ListMinimumSalariesService))?.GetTypes()
                .Where(m => m.IsPublic && !m.IsAbstract).ToList();

            if (classTypes == null)
                return;

            foreach (var type in interfaceTypes)
            {
                var result = classTypes.FirstOrDefault(m => m.GetInterfaces().Contains(type));
                if (result == null)
                    continue;
                services.AddScoped(type, result);
            }
        }
    }
}
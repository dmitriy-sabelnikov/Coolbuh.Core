using Coolbuh.Core.Controllers;
using Coolbuh.Core.DataAccess.MsSql;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Queries.GetListDepartments;
using Coolbuh.Core.WebCore.DependencyInjection;
using Coolbuh.Core.WebCore.Middleware;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Coolbuh.Core.WebCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region DBConfigure

            services.AddDbContext<IDbContext, AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MsSqlConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                ));

            services.AddDatabaseDeveloperPageExceptionFilter();

            #endregion

            #region AppConfigure

            //services.AddCors();
            services.AddMediatR((configuration) => 
            {
                configuration.RegisterServicesFromAssembly(typeof(GetListDepartmentsRequest).Assembly);
            } );
            services.AddDomainServices();
            services.AddControllers().AddApplicationPart(typeof(ListDepartmentsController).Assembly);
            services.AddSwagger();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var urls = Configuration[WebHostDefaults.ServerUrlsKey];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Url listener:     ");
                Console.ResetColor();
                Console.WriteLine(urls);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Swagger listener: ");
                Console.ResetColor();
                Console.WriteLine(urls + "/swagger/index.html");
                Console.WriteLine(new string('=', 100));
            }

            //app.UsePerfomanceMiddleware();
            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Coolbuh API V1"));

            app.UseExceptionMiddleware();

            app.UseRouting();

            //app.UseCors(c => c.AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}

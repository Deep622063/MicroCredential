using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models.Model;
using QuoteManagement.Helper;
using QuoteManagement.Services;
using Repository.Repository;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuoteManagement
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
            services.AddControllers();
            services.AddDbContext<QuoteDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);
            services.AddApiVersioning();
            services.AddSingleton<IQuoteServices, QuoteServices>();
            services.AddSingleton<IDataRepository<Quote>, DataRepository<Quote, QuoteDbContext>>();
            services.AddSingleton<IQuoteHelper, QuoteHelper>();
            services.AddSwaggerGen(swaggerOptions =>
            {
                swaggerOptions.SwaggerDoc("Customers", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Customers",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, QuoteDbContext quoteDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = (c) =>
                {
                    var exception = c.Features.Get<IExceptionHandlerFeature>();
                    var message = "There has been some error";
                    var statusCode = exception.Error.GetType().Name switch
                    {
                        "ArgumentException" => HttpStatusCode.BadRequest,
                        "DbUpdateConcurrencyException" => HttpStatusCode.NotFound,
                        _ => HttpStatusCode.InternalServerError
                    };
                    switch (statusCode)
                    {
                        case HttpStatusCode.BadRequest:
                            message = "Invalid request";
                            break;
                        case HttpStatusCode.NotFound:
                            message = "No records found";
                            break;
                    }
                    c.Response.StatusCode = (int)statusCode;
                    var content = Encoding.UTF8.GetBytes(message);
                    c.Response.Body.WriteAsync(content, 0, content.Length);
                    return Task.CompletedTask;
                }
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            quoteDbContext.Database.EnsureCreated();

            app.UseSwagger();
            app.UseSwaggerUI(swaggerUIOptions =>
            {
                swaggerUIOptions.SwaggerEndpoint("/swagger/QuoteManagement/swagger.json", "QuoteManagementApi V1");
            });
        }
    }
}

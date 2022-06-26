using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Examples.RabbitMQ.Producer
{
	public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(
				//c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer
				//{
				//	Url = 
				//})				//c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer
				//{
				//	Url = 
				//})
			);

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(host: Configuration["RabbitMq:Uri"], h =>
                   {
                       h.Username(Configuration["RabbitMq:Username"]);
                       h.Password(Configuration["RabbitMq:Password"]);
                   });

                    cfg.ConfigureEndpoints(context);
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
			
			//app.UsePathBase(Configuration["BasePath"]);			

			app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Producer API V1");
                c.RoutePrefix = "swagger";
				//c.RootUrl(req => { return "http://localhost:8080/myapi"; });
				//c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
				//{
				//	swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{basePath}" } };
				//});
			});

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
            });
        }
    }
}
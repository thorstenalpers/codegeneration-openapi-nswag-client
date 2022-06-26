using Examples.RabbitMQ.Consumer.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Examples.RabbitMQ.Consumer
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
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<SomeEventReceivedHandler>()
                    .Endpoint(e =>
                    {
                        //e.
                        // override the default endpoint name
                        //e.Name = "order-service-extreme";

                        // specify the endpoint as temporary (may be non-durable, auto-delete, etc.)
                        e.Temporary = false;

                        // specify an optional concurrent message limit for the consumer
                        e.ConcurrentMessageLimit = 8;

                        // only use if needed, a sensible default is provided, and a reasonable
                        // value is automatically calculated based upon ConcurrentMessageLimit if
                        // the transport supports it.
                        e.PrefetchCount = 16;

                        // set if each service instance should have its own endpoint for the consumer
                        // so that messages fan out to each instance.
                        //e.InstanceId = "something-unique";
                    }
                );

                cfg.AddBus(provider =>
                {
                    return Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        cfg.Host(host: Configuration["RabbitMq:Uri"], h =>
                        {
                            h.Username(Configuration["RabbitMq:Username"]);
                            h.Password(Configuration["RabbitMq:Password"]);
                        });
                        cfg.ReceiveEndpoint("EventReceived", e =>
                        {
                            e.Consumer<SomeEventReceivedHandler>(provider);
                        });
                    });
                });
            });

            services.AddHostedService<MassTransitHostedService>();

            services.AddSingleton<SomeEventReceivedHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
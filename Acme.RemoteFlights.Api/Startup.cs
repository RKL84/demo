using Acme.RemoteFlights.Api.Commands;
using Acme.RemoteFlights.Core;
using Acme.RemoteFlights.Core.Commands;
using Acme.RemoteFlights.Core.Queries;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Model;
using System;
using System.Reflection;

namespace Acme.RemoteFlights.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var constr = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<AcmeObjectContext>
              (options => options.UseSqlServer(constr));

            services.AddMvc().AddJsonOptions(o =>
            {
                o.SerializerSettings.NullValueHandling =
                Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Acme.RemoteFlight API"
                });
                options.DescribeAllEnumsAsStrings();
            });

            // Plug Autofac
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterType<FlightManangementCommandBus>().As<ICommandBus>();
            builder.RegisterType<BookingQueries>().As<IBookingQueries>();
            builder.RegisterInstance(Configuration);
            builder.RegisterType<FlightQueries>().As<IFlightQueries>();

            // Register CommandHandlers
            builder.RegisterAssemblyTypes(typeof(Startup).GetTypeInfo().Assembly)
                 .AsClosedTypesOf(typeof(ICommandHandler<>))
                 .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();

            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUi();
            app.UseMvc();
        }
    }
}

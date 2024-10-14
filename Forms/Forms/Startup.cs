using Forms.Consumers;
using Forms.FormsContext;
using Forms.Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace Forms;


public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: "AllowOrigin", builder =>
            {
                builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
            });
        });

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddControllers();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddDbContext<FormsDatabaseContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("FormsDbConnection"));
        }
        );
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();
            busConfigurator.AddConsumer<ExamConsumer>();


            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(Configuration["MessageBroker:Host"]!), h =>
                {
                    h.Username(Configuration["MessageBroker:Username"]);
                    h.Password(Configuration["MessageBroker:Password"]);
                });
                //configurator.ReceiveEndpoint("forms-queue", e =>
                //{
                //    e.Bind("Questions.Dtos:ExamDto");
                //    e.Bind<ExamDto>();
                //    e.ConfigureConsumer<ExamConsumer>(context);
                //});+

                configurator.ConfigureEndpoints(context);
            });
        });
        services.AddOpenApiDocument(o => o.SchemaSettings.SchemaNameGenerator = new CustomSwaggerSchemaNameGenerator());
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors("AllowOrigin");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });


        app.UseOpenApi();
        app.UseSwaggerUI();
    }
}

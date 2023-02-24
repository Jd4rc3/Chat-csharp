using Chat.AppServices.Auth.Extensions;
using Helpers.ObjectsUtils;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SC.Configuration.Provider.Mongo;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region Host Configuration

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonProvider();

builder.Host.UseSerilog((ctx, lc) => lc
       .WriteTo.Console()
       .ReadFrom.Configuration(ctx.Configuration));

#endregion Host Configuration

builder.Services.Configure<ConfiguradorAppSettings>(builder.Configuration.GetRequiredSection(nameof(ConfiguradorAppSettings)));
ConfiguradorAppSettings appSettings = builder.Configuration.GetSection(nameof(ConfiguradorAppSettings)).Get<ConfiguradorAppSettings>();
string country = EnvironmentHelper.GetCountryOrDefault(appSettings.DefaultCountry);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Service Configuration

string policyName = "cors";
builder.Services
    .RegisterCors(policyName)
    .RegisterAutoMapper()
    .RegisterServices()
    .RegisterMongo(appSettings.MongoConnection, $"{appSettings.Database}_{country}")
    .AddVersionedApiExplorer();

builder.Services
    .AddHealthChecks();

#endregion Service Configuration

WebApplication app = builder.Build();

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseCors(policyName);
app.UseHttpsRedirection();
app.Run();
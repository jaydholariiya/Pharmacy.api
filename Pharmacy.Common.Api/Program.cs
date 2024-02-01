using Pharmacy.Common.Api.Infrastructure.Extensions;
using Pharmacy.Common.Api.Middleware;
using Pharmacy.Common.Util.Config;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Net.Http.Headers;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                           .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                           .AddEnvironmentVariables();

ConfigurationManager configuration = builder.Configuration;

var services = builder.Services;


services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

configuration.AddLoggerCustom();
services.AddDependencyInjectionCustom();
// services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
configuration.AddDatabase();
services.AddAutoMapper();
services.AddCorsCustom();

services.AddOptions();
services.AddCustomFilters();
services.AddSwaggerUICustom();
services.AddControllers();

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

if (app.Environment.IsDevelopment()) { app.UseDeveloperExceptionPage(); } else { app.UseHsts(); }

app.UseHttpsRedirection();

app.UseCorsCustom();
app.UseStaticFiles();
app.ConfigureSwaggerUI(configuration);
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Run();
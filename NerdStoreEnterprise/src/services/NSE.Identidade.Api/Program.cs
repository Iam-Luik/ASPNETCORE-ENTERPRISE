using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NSE.Identidade.Api.Configuration;
using NSE.Identidade.Api.Data;
using NSE.Identidade.Api.Extensions;

var builder = WebApplication.CreateBuilder();

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath);
builder.Configuration.AddJsonFile("appsettings.json", true, true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
builder.Configuration.AddEnvironmentVariables();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<StartupBase>();
}

builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddApiConfiguration();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

app.UseApiConfiguration(app.Environment);

app.UseSwaggerConfiguration(app.Environment);

app.MapControllers();

app.Run();
using System.Reflection;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using FluentValidation.AspNetCore;
using PresidioAcademy.API;
using PresidioAcademy.Application;
using PresidioAcademy.Application.Validators;
using PresidioAcademy.Infrastructure;


// Add Configurations rom Azure Key Vault
var builder = WebApplication.CreateBuilder(args);
var secretClient = new SecretClient(
    new Uri(builder.Configuration["KeyVault:VaultUri"]),
    new DefaultAzureCredential());

builder.Configuration.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
//Get Configuration manager
var configurations = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(options =>
{
    // Validate child properties and root collection elements
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;

    // Automatic registration of validators in assembly
    options.RegisterValidatorsFromAssemblyContaining<EmployeeValidator>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddPersistance(configurations);
builder.Services.AddServices(configurations);
builder.Services.AddJWT(configurations);
//Cors Service
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.UseCors("corsapp");
app.MapControllers();

app.Run();
using System.Reflection;
using FluentValidation.AspNetCore;
using PresidioAcademy.API;
using PresidioAcademy.Application;
using PresidioAcademy.Application.Validators;
using PresidioAcademy.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
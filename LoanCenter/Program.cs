using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

using LoanCenter.Models;
using LoanCenter.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<LoanRequest>, LoanRequestValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => {
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Loan Request API",
        Version = "v1",
        Description = "Accepts customer loan requests and determines eligibility."
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    x.ExampleFilters();
});
builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x => {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Loan Request API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization(); 
app.MapControllers();

app.Run();

// Make auto-generated Program class public so it is accessible elsewhere (e.g. LoanCenter.Tests)
public partial class Program {}
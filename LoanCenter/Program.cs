using Microsoft.OpenApi.Models;
using System.Reflection;

using LoanCenter.Models;

var builder = WebApplication.CreateBuilder(args);

var minimalAPIMode = true;

if (!minimalAPIMode)
{
    builder.Services.AddControllers();
}

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
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x => {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Loan Request API V1");
    });
}

app.UseHttpsRedirection();

if (!minimalAPIMode)
{
    app.UseAuthorization(); 
    app.MapControllers();
}
else
{
    app.MapGet("/index", () => "Hello Nick!")
        .Produces<string>(StatusCodes.Status200OK, "text/plain");

    app.MapPost("/loanrequest", (LoanRequest request) =>
        {
            Console.WriteLine(request.EmailAddress);
            return Results.StatusCode(201);
        }
    )
        .Accepts<LoanRequest>("application/json")
        .Produces(StatusCodes.Status201Created);
}

app.Run();

// Make auto-generated Program class public so it is accessible elsewhere (e.g. LoanCenter.Tests)
public partial class Program {}
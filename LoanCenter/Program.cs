using LoanCenter.Models;

var builder = WebApplication.CreateBuilder(args);

var minimalAPIMode = true;

if (!minimalAPIMode)
{
    builder.Services.AddControllers();
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

if (!minimalAPIMode)
{
    app.UseAuthorization();
    app.MapControllers();
}
else
{
    app.MapGet("/index", () => "Hello Nick!");
    app.MapPost("/loanrequest", async (LoanRequest request) =>
        {
            Console.WriteLine(request.EmailAddress);
            return Results.StatusCode(201);
        }
    );
}

app.Run();

// Make auto-generated Program class public so it is accessible elsewhere (e.g. LoanCenter.Tests)
public partial class Program {}
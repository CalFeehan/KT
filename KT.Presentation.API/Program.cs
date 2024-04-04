using KT.Application;
using KT.Infrastructure;
using KT.Presentation.API.Middleware;
using KT.Presentation.Contracts;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();
    
    builder.Services
        .AddContracts()
        .AddApplication()
        .AddInfrastructure();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.UseMiddleware<ErrorHandlingMiddleware>();

    app.Run();
}
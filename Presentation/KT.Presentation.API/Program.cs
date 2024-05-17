using KT.Application;
using KT.Infrastructure;
using KT.Presentation.API;
using KT.Presentation.API.Middleware;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApi()
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
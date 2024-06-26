using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    
    // Registering the filter globally
    // builder.Services.AddControllers(options
    //     => options.Filters.Add<ErrorHandlingFilterAttribute>());
}

var app = builder.Build();
{
    // Middleware for handling exceptions
    // app.UseMiddleware<ErrorHandlingMiddleware>();

    // Configure the HTTP request pipeline to handle exceptions
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

using BuildingBlocks.Behaviours;
using BuildingBlocks.Excpetions.Handler;

var builder = WebApplication.CreateBuilder(args);
//Add services to the container 
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddCarter();
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);

}).UseLightweightSessions();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
var app = builder.Build();
app.UseExceptionHandler(opts=> {  });
app.MapCarter();

app.Run();

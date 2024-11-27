var builder = WebApplication.CreateBuilder(args);
//Add services to the container 
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddCarter();
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);

}).UseLightweightSessions();
var app = builder.Build();

app.MapCarter();

app.Run();

using System.Text.Json.Serialization;
using dotenv.net;
using Booxer.WebAPI.Pipeline.Cors;
using Booxer.WebAPI.Pipeline.Handlers;
using Booxer.WebAPI.Pipeline.Middlewares;
using Booxer.Application;
using Booxer.Infrastructure.Identity;
using Booxer.Infrastructure.Persistence;
using Booxer.Infrastructure.Persistence.Context;
using Booxer.Infrastructure.Persistence.Seeding;

DotEnv.Load(options: new DotEnvOptions(envFilePaths: ["../.env"]));

var builder = WebApplication.CreateBuilder(args);

// LAYERS CONFIG
builder.Services.ConfigureApplication();
builder.Services.ConfigurePersistence();
builder.Services.ConfigureIdentity();

// CORS
builder.Services.ConfigureCorsPolicy();

// CONTROLLERS AND OPTIONS
builder.Services.AddControllers().AddJsonOptions(op =>
{
    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<BooxerContext>()
    ?? throw new InvalidOperationException("Failed to resolve BooxerContext from service provider.");

dataContext.Database.EnsureCreated();
await dataContext.SeedData();

app.UseMiddleware<SessionMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseErrorHandler();
app.MapControllers();
app.Run();

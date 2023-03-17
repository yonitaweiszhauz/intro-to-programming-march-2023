using LearningResourcesApi.Adapters;
using LearningResourcesApi.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
var apiUri = builder.Configuration.GetValue<string>("onCallApiUrl");
<<<<<<< HEAD:LearningResourcesSolution/LearningResourcesApi/Program.cs
if (apiUri == null)
{
    throw new Exception("Don't have an api url! Don't start this service!");
=======

if (apiUri == null)
{
    throw new Exception("Don't Have an Api Url! Don't Start This Service!");
>>>>>>> 388a08c5e60f3c733a73e047e94cb004f61bf5c2:instructor/LearningResourcesSolution/LearningResourcesApi/Program.cs
}
builder.Services.AddHttpClient<OnCallDeveloperLookupApiAdapter>(client =>
{
    client.BaseAddress = new Uri(apiUri);
});

builder.Services.AddScoped<ILookupOnCallDevelopers, ApiOnCallDeveloperLookup>();
<<<<<<< HEAD:LearningResourcesSolution/LearningResourcesApi/Program.cs

=======
>>>>>>> 388a08c5e60f3c733a73e047e94cb004f61bf5c2:instructor/LearningResourcesSolution/LearningResourcesApi/Program.cs
builder.Services.AddCors(config =>
{
    config.AddDefaultPolicy(pol =>
    {
        pol.AllowAnyOrigin();
        pol.AllowAnyMethod();
        pol.AllowAnyHeader();
    });
});


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
<<<<<<< HEAD:LearningResourcesSolution/LearningResourcesApi/Program.cs

=======
>>>>>>> 388a08c5e60f3c733a73e047e94cb004f61bf5c2:instructor/LearningResourcesSolution/LearningResourcesApi/Program.cs
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TWO services.
// builder.Services.AddSingleton<ISystemTime, SystemTime>()
builder.Services.AddDbContext<LearningResourcesDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("resources"));
});

builder.Services.AddScoped<IManageLearningResources, EntityFrameworkResourceManager>();
var app = builder.Build();

app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

// See https://aka.ms/new-console-template for more information

using Marten;
using Status;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(pol =>
    {
        pol.AllowAnyOrigin();
        pol.AllowAnyHeader();
        pol.AllowAnyMethod();
    });
});

var connectionString = "host=localhost;database=status_dev;username=postgres;password=TokyoJoe138!;port=5432";

builder.Services.AddMarten(options =>
{
    options.Connection(connectionString);
    options.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;
}
);

// we configure "services"

var app = builder.Build();

app.UseCors();

app.MapGet("/status", async (IDocumentSession db) =>
{
    var response = await db.Query<StatusMessage>()
    .OrderByDescending(sm => sm.When)
    .FirstOrDefaultAsync(); if (response == null)
    {
        return Results.Ok(new StatusMessage(Guid.NewGuid(), "No Status to Report", DateTimeOffset.Now));
    }
    else
    {
        return Results.Ok(response);
    }
});

app.MapPost("/status", async (StatusChangeRequest request, IDocumentSession db) =>
{
    // save this in the database 
    var messageToSave = new StatusMessage(Guid.NewGuid(), request.Message, DateTimeOffset.Now);
    db.Store<StatusMessage>(messageToSave);
    await db.SaveChangesAsync(); // do it!
    return Results.Ok(messageToSave);
});

app.Run(); // "Block"






// Console.WriteLine("This is a .NET Application!");
// Console.WriteLine("Another line!"); s
//var statusId = Guid.NewGuid().ToString();
//var statusMessage = "Looks good. Just learning some .net";
//var statusTime = DateTimeOffset.Now;

// var statusMessage = new StatusMessage(Guid.NewGuid(), "Looks Good", DateTimeOffset.Now); 

// Console.WriteLine($"The id {statusMessage.Id} status: {statusMessage.Message} at {statusMessage.When}");
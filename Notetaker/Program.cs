using Notetaker.DataAccess;
using Notetaker.Interfaces;
using Notetaker.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
void ConfigureServices(IServiceCollection services)
{
	// Register the NoteService as the implementation of INoteService.
	services.AddScoped<INoteService, NoteService>();
	
}
// Other service registrations...
builder.Services.Configure<MongoDBSettings>(
builder.Configuration.GetSection("MyDBSettings"));

builder.Services.AddTransient<INoteService, NoteService>();



// Other service registrations...
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

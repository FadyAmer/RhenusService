using Rhenus_Special_Delivery.DataAccess;
using Rhenus_Special_Delivery.DataAccess.Players.Readers;
using Rhenus_Special_Delivery.DataAccess.Players.Writers;
using Rhenus_Special_Delivery.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RhenusContext>();
builder.Services.AddScoped<RhenusContext, RhenusContext>();
builder.Services.AddScoped<IPlayerReader, PlayerReader>();
builder.Services.AddScoped<IPlayerWriter, PlayerWriter>();
builder.Services.AddScoped<IRhenusService, RhenusService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var context = new RhenusContext())
    {
        context.Database.EnsureCreated();
        var players = context.Players.ToList();
    }
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

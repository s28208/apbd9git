using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Repositors;
using WebApplication1.Servers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<Apbd901Context>(
    options => options.UseSqlServer(connectionString: "Name=ConnectionStrings:Default"));
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<ITripServer, TripServer>();
builder.Services.AddScoped<IClientServer, ClientServer>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

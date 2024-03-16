using API_Mission10_Oliveira.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();




builder.Services.AddDbContext<BowlingContext>(options =>
 
     options.UseSqlite(builder.Configuration["ConnectionStrings:Bowling"])
 );

builder.Services.AddScoped<IBowlingRepository, EFBowlingRepository>();

//builder.Services.AddScoped<IBowlRepository, EFBowlRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p.WithOrigins("http://localhost:3000"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

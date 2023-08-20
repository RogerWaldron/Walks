using Microsoft.EntityFrameworkCore;
using Walks.API.Data;
using Walks.API.Repositories.Region;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRegionRepository, RegionRepository>();

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program).Assembly);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WalksDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WalksConnectionString"))
    );

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


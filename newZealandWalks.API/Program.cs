using Microsoft.EntityFrameworkCore;
using newZealandWalks.API.Data;
using newZealandWalks.API.Mappings;
using newZealandWalks.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// egen DI
builder.Services.AddDbContext<newZealandWalksDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("newZealandWalksConnectionString")));
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
// builder.Services.AddScoped<IRegionRepository, InMemoryRegionRepository>(); // bytte DB
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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

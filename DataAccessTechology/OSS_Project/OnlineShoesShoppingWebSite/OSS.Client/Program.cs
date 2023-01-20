using Microsoft.EntityFrameworkCore;
using OSS.Business.Abstraction;
using OSS.Data.Entity;
using OSS.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IManufacturersRepository, ManufacturersRepository>();
builder.Services.AddScoped<IFootwearDetailsRepository, FootwearDetailsRepository>();

builder.Services.AddDbContext<OSSContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("OssDb")));

// Add services to the container.

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

app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();

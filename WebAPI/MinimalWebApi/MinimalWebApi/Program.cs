using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MiniDemo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddDbContext<PatientDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb")));

// Add services to the container.
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

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger(x => x.SerializeAsV2 = true);
app.MapGet("/patient/{id}", ([FromServices] IPatientRepository db, int id) =>
{
    return db.GetPatientById(id);
});


app.MapGet("/patient", ([FromServices] IPatientRepository db) =>
{
    return db.GetPatient();
}
);

app.MapPut("/patient/{id}", ([FromServices] IPatientRepository db, Patient patient) =>
{
    return db.PutPatient(patient);
});

app.MapPost("/patient", ([FromServices] IPatientRepository db, Patient patient) =>
{
    return db.AddPatient(patient);
});

app.Run();


using Application.interfaces;
using Application.Services;
using Domain.Data;
using Domain.interfaces;
using Infrastructure.Repositories;
using WebApi.MiddleWares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<Database>();
builder.Services.AddScoped<IPatientRepository , PatientRepository>();
builder.Services.AddScoped<IPatientService , PatientService>();

builder.Services.AddScoped<IDoctorRepository , DoctorRepository>();
builder.Services.AddScoped<IDoctorService , DoctorService>();

builder.Services.AddScoped<IRoomRepository , RoomRepository>();
builder.Services.AddScoped<IRoomService , RoomService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<RequestLoggingMiddleWare>();
app.MapControllers();
app.Run();
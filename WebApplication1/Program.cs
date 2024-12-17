using ATMApplication.Application.Contract;
using ATMApplication.Application.Services;
using ATMApplication.Infrastracture;
using Microsoft.AspNetCore.Authentication;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<ATMContext>();
builder.Services.AddTransient(typeof(IAsyncRepsoitory<>), typeof(AsyncRepository<>));
builder.Services.AddScoped<IAccountAppService, AccountAppService>();
builder.Services.AddScoped<IUserAccountService, UserAccountAppService>();
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

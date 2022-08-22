// ----------------------------------------------------------------------------------------------------- //
//                                                                                                       //
// @File      Program.cs                                                                                 //
// @Details   configure the different services in app and build the app                                  //
// @Author    Or Abergil                                                                                 //
// @Since     11/07/2022                                                                                 //
//                                                                                                       //
// ----------------------------------------------------------------------------------------------------- //

using RateLimit.Services.Interfaces;
using RateLimit.Services;
using RateLimit.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRateLimiterService, RateLimiterService>();
builder.Services.AddSingleton<ILogicService, LogicService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

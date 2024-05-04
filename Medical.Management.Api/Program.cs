using Medical.Management.Application.Extensions;
using Medical.Management.Infra.Extensions;
using Smart.Essentials.Filters;
using Smart.Essentials.Security.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfra(builder.Configuration)
    .AddApplication();
builder.Services.AddControllers(options =>
{
    //options.Filters.Add(typeof(DefaultExceptionFilterAttribute));
    //options.Filters.Add(typeof(ValidationFilter));
    options.Filters.Add(typeof(NotificationFilter));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureJwt();
builder.Services.ConfigureSwagger();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapHealthChecks("/health");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

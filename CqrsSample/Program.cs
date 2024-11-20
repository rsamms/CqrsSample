using CqrsSample.Framework.Mediatr;
using CqrsSample.Framework.MemCache;
using CqrsSample.Framework.Sql;
using CqrsSample.Middleware;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<ICacheProvider, CacheProvider>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddExceptionHandler<ExceptionMiddleware>();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => { 
    cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

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
app.UseExceptionHandler();
app.Run();

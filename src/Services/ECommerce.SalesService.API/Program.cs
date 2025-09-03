using Asp.Versioning.ApiExplorer;
using ECommerce.SalesService.API.SwaggerConfig;
using ECommerce.SalesService.Domain.Application.Commands.CreateOrder;
using ECommerce.SalesService.Domain.Core.Interfaces.Repositories;
using ECommerce.SalesService.Infrastructure.Data.Context;
using ECommerce.SalesService.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// Configuração do MediatR
builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("ECommerce.SalesService.Domain.Application"));

// Configuração do AutoMapper
builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApiVersioning()
    .AddMvc()
    .AddApiExplorer(setup =>
    {
        setup.GroupNameFormat = "'v'VVV";
        setup.SubstituteApiVersionInUrl = true;
    });

builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();
builder.Services.AddHttpClient();

// Adiciona o DbContext do SalesService usando PostgreSQL
builder.Services.AddDbContext<SalesServiceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL_Estudos_Local")));

// Repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Handlers
builder.Services.AddScoped<IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>, CreateOrderCommandHandler>();

var app = builder.Build();
    
app.MapOpenApi();
app.UseHttpsRedirection();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var version = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    foreach (var description in version.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"Sales Api - {description.GroupName.ToUpper()}");
    }
});

app.Run();

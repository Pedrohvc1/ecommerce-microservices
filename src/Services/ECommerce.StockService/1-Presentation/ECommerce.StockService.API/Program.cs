using Asp.Versioning.ApiExplorer;
using ECommerce.StockService.API.SwaggerConfig;
using ECommerce.StockService.Domain.Application.Commands.CreateProduct;
using ECommerce.StockService.Domain.Core.Interfaces.Repositories;
using ECommerce.StockService.Infrastructure.Data.Context;
using ECommerce.StockService.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// Configuração do MediatR
builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("ECommerce.StockService.Domain.Application"));

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
// Adiciona o DbContext do StockService usando PostgreSQL
builder.Services.AddDbContext<StockServiceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL_Estudos_Local")));

// Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Handlers
builder.Services.AddScoped<IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>, CreateProductCommandHandler>();

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
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
            $"Web Api - {description.GroupName.ToUpper()}");
    }
});

app.Run();
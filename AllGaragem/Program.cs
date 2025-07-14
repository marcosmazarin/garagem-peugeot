using AllGaragem.Application.ProductCheckout.DTO.Product.Actions.Create;
using AllGaragem.Application.ProductCheckout.Interfaces.Product.Actions.Create;
using AllGaragem.Application.ProductCheckout.UseCases.Product.Actions.Create;
using AllGaragem.Domain.Interfaces;
using AllGaragem.Infrastructure.Persistence;
using DotNetEnv;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

string? urlSupabase = Environment.GetEnvironmentVariable("SUPABASE_URL");
string? keySupabase = Environment.GetEnvironmentVariable("SUPABASE_KEY");

if (urlSupabase == null || keySupabase == null)
    throw new ArgumentNullException(urlSupabase == null ? nameof(urlSupabase) : nameof(keySupabase));

builder.Services.AddSingleton(provider => new Supabase.Client(urlSupabase, keySupabase));

builder.Services.AddScoped<IValidator<CreateProductRequestDTO>, CreateProductRequestDTOValidator>();

builder.Services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
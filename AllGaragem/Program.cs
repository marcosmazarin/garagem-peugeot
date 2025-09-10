using System.Reflection;
using AllGaragem.IoC;
using DotNetEnv;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MZM Safelink API",
        Contact = new OpenApiContact
        {
            Name = "Project",
            Url = new Uri("https://github.com/marcosmazarin"),
            Email = ""
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDataBaseConfig();
builder.Services.AddValidatorsConfigIoC();
builder.Services.AddUseCases();
builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseRouting();
app.MapControllers();

//app.UseHttpsRedirection();

app.Run();
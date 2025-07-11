var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

string? urlSupabase = Environment.GetEnvironmentVariable("SUPABASE_URL");
string? keySupabase = Environment.GetEnvironmentVariable("SUPABASE_KEY");

if (urlSupabase == null || keySupabase == null)
    throw new ArgumentNullException(urlSupabase == null ? nameof(urlSupabase) : nameof(keySupabase));

builder.Services.AddSingleton(provider => new Supabase.Client(urlSupabase, keySupabase));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
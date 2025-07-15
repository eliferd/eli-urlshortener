using EliURLShortenerApi.Database;
using EliURLShortenerApi.Models;
using EliURLShortenerApi.Repositories;
using EliURLShortenerApi.Services;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddEnvironmentVariables();

        // Add services to the container.
        var connectionString = builder.Environment.IsDevelopment() ? "Dev" : "Production"; // Production string obviously omitted from appsettings.json as it is set by machine env var
        builder.Services.AddDbContext<UrlDbContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString(connectionString)));
        builder.Services.AddScoped<IUrlRepository<Url>, UrlRepository>();
        builder.Services.AddScoped<IUrlService<Url>, UrlService>();

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<UrlDbContext>();
            db.Database.Migrate();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(options =>
        {
            if (app.Environment.IsDevelopment())
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
            } else
            {
                options.WithOrigins("https://url.eliferd.fr")
                .AllowAnyHeader()
                .AllowAnyMethod();
            }
            
        });

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}
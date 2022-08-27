using Microsoft.Extensions.FileProviders;
using ToDo.Models;

namespace ToDo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            var builder = WebApplication.CreateBuilder(args);

            // Setup Configuration source.
            builder.Configuration
                // Below two are included in the DefaultBuilder
                //.AddJsonFile("appsettings.json", optional: true)
                //.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables(prefix: "ToDo_");
            string? parentPath = Directory.GetParent(builder.Environment.ContentRootPath)?.FullName;
            if (!string.IsNullOrEmpty(parentPath))
            {
                PhysicalFileProvider srvFileProvider = new(parentPath);
                builder.Configuration
                    .AddJsonFile(srvFileProvider, "appsettings.Srv.json", optional: true, reloadOnChange: true);
            }

            // Add services to the container - ConfigureServices in Startup
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSingleton<ToDoName>();

            var app = builder.Build();

            // Configure the HTTP request pipeline - Configure in Startup
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddEnvironmentVariables(prefix: "ToDo_");
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
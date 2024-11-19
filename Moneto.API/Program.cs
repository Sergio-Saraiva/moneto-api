
using Moneto.Domain.Settings;
using Moneto.IOC;

namespace Moneto.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var environment = builder.Environment.EnvironmentName;
        var appSettings = builder.Configuration.AddJsonFile(
                $"appsettings.{builder.Environment.EnvironmentName}.json",
                optional: true,
                reloadOnChange: true
            ).Build()
            .Get<AppSettings>();

        // Add services to the container.
        builder.Services.AddAppSettings(appSettings);
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddPostgres(appSettings);
        builder.Services.AddAppMediatR();
        builder.Services.AddAppDependencyInjection();
        builder.Services.AddAutoMapper();
        if(builder.Environment.IsDevelopment()) {
            builder.Services.AddDevCookieDependencyInjection();
            builder.Services.AddDevCors(appSettings);
        }
        if(!builder.Environment.IsDevelopment()) {
            builder.Services.AddProdCookieDependencyInjection();
            builder.Services.AddProdCors(appSettings);
        }
        builder.Services.AddAuthentication();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("DevCorsPolicy");
            app.UseCookiePolicy(new CookiePolicyOptions {
                Secure = CookieSecurePolicy.None,
            });
        }

        if (!app.Environment.IsDevelopment())
        {
            app.UseCors("ProdCorsPolicy");
            app.UseCookiePolicy(new CookiePolicyOptions {
                Secure = CookieSecurePolicy.Always,
            });
            app.UseHttpsRedirection();
        }

        app.UseAuthentication();
        
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

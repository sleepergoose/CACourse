using PackIt.Application;
using PackIt.Infrastructure;
using PackIt.Shared.Extensions;

namespace PackIt.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddShared();
        builder.Services.AddAplication();
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();


        // Middlewares
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseShared();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

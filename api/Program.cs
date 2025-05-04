using AutoMapper;
using CaseEstudo1.Architecture.AutoMapper;
using CaseEstudo1.Architecture.Interfaces;
using CaseEstudo1.Architecture.Services;
using CaseEstudo1.Data;
using CaseEstudo1.Middleware;
using Microsoft.EntityFrameworkCore;


namespace CaseEstudo1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IBordaService, BordaService>();
            builder.Services.AddScoped<IPizzaService, PizzaService>();
            builder.Services.AddScoped<IBebidaService, BebidaService>();
            builder.Services.AddScoped<IIngredienteService, IngredienteService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DbInitializer.Initialize(context);
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthorization();
            app.MapControllers();

            app.Urls.Add("http://*:80");

            app.Run();
        }
    }
}


using Day1WebApi.Interface;
using Day1WebApi.Model.Database;
using Day1WebApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace Day1WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<Studentdbcontext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("StdConnection"))
                );

            builder.Services.AddScoped<IStudentRep, StudentERep>();
            builder.Services.AddScoped<IDepartmentRep, DepartmentRep>();

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("Open", crosPolicy =>
                {
                    crosPolicy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseCors("Open");

            app.MapControllers();

            app.Run();
        }
    }
}

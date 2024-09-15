using Dnc.Staff.Data;
using Dnc.Staff.Data.Models.Entities;
using Dnc.Staff.Repository;
using Dnc.Staff.Repository.Interfaces;
using Dnc.Staff.Services;
using Dnc.Staff.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

namespace Dnc.Staff.ApiApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<StaffDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
            });

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IStaffDepartmentService, StaffDepartmentService>();
            builder.Services.AddScoped<IStaffEmployeeService, StaffEmployeeService>();
            builder.Services.AddScoped<IStaffProjectService, StaffProjectService>();


            builder.Services.AddControllers()
                .AddJsonOptions(options => { 
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

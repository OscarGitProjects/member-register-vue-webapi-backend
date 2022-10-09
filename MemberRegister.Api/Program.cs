using MemberRegister.Api.Services;
using MemberRegister.Core.Repositories;
using MemberRegister.Data.Data;
using MemberRegister.Data.Repositories;
using Microsoft.EntityFrameworkCore;


namespace MemberRegister.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(o => o.AddPolicy("MemberRegisterPolicy", builder => {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MemberDBHome")));

            builder.Services.AddScoped<IMemberRegisterService, MemberRegisterService>();
            builder.Services.AddScoped<IMemberRegisterRepository, MemberRegisterRepository>();

            builder.Services.AddAutoMapper(typeof(MapperProfile));

            builder.Services.AddLogging();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("MemberRegisterPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}
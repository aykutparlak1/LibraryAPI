using LibraryAPI.Application.DependencyResolvers;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Core.Extensions;
using LibraryAPI.Core.Utilities.IoC;
using LibraryAPI.Persistence.Context;
using LibraryAPI.Persistence.DependencyResolvers;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Configure connection string
            builder.Services.AddDbContext<LibraryContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString1"))

                );
            builder.Services.AddDependencyResolvers(new ICoreModule[] { new PersistenceServiceRegistrations() ,new ApplicationServiceRegistrations()});

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

           // builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>policy.WithOrigins("domain1","domain2").AllowAnyHeader().AllowAnyMethod())); Herkes eriþebilirr app.UseCors middlewareýný caðýrarak eriþip etkinleþtirmemiz gerekiyor.
            var app = builder.Build();
            app.ConfigureCustomExceptionMiddleware();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            //app.UseCors();
            //yukarda belirlediðimiz cors politikasý cagýrýyoruz.

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
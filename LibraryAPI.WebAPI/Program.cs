using LibraryAPI.Application.DependencyResolvers;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Core.DependencyResolvers;
using LibraryAPI.Core.Extensions;
using LibraryAPI.Core.Utilities.IoC;
using LibraryAPI.Core.Utilities.Security.Encryption;
using LibraryAPI.Core.Utilities.Security.JWT;
using LibraryAPI.Persistence.Context;
using LibraryAPI.Persistence.DependencyResolvers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            builder.Services.AddDependencyResolvers(new ICoreModule[] { new CoreServiceRegistrations(), new PersistenceServiceRegistrations() ,new ApplicationServiceRegistrations()});

            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });


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
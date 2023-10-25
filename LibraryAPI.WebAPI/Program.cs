using Autofac;
using Autofac.Extensions.DependencyInjection;
using LibraryAPI.Application.DependencyResolvers;
using LibraryAPI.Core.Aspects.WebApiFilters;
using LibraryAPI.Core.Utilities.DependencyResolvers;
using LibraryAPI.Core.Utilities.Extensions;
using LibraryAPI.Core.Utilities.IoC;
using LibraryAPI.Core.Utilities.Security.Encryption;
using LibraryAPI.Core.Utilities.Security.JWT;
using LibraryAPI.Persistence.Context;
using LibraryAPI.Persistence.DependencyResolvers;
using LibraryAPI.Persistence.Migrations;
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
            // AddDbContextPool baðlantý havuzu olustuuruyor her seferinde yeniden olusturmak yerine baglantý havuzundan hýzlý bir þekilde kullanýyor
            builder.Services.AddDbContext<LibraryContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString1"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                );


            builder.Services.AddDependencyResolvers(
                new ICoreModule[] 
                {
                    new CoreServiceRegistrations(),
                    new PersistenceServiceRegistrations(),
                    new ApplicationServiceRegistrations()
                }
                );


            builder.Services.AddHttpContextAccessor();


            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
            builder.RegisterModule(new AutofacModuleBinding());
            });



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



            builder.Services.AddStackExchangeRedisCache(opt=>opt.Configuration=builder.Configuration.GetConnectionString("Redis"));

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
            //Servicede belirlediðimiz cors politikasý cagýrýyoruz.
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.MapControllers();



            app.MigrationDatabase();
            app.Run();
        }
    }
}
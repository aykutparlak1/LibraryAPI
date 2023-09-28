using LibraryAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibraryAPI.Persistence.Migrations
{
    public static class MigrationHelper
    {
        public static IHost MigrationDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope()) /// RunTime upateDatabase migrate
            {
                using (var context = scope.ServiceProvider.GetRequiredService<LibraryContext>())
                {
                    try
                    {
                        context.Database.Migrate();
                    }
                    catch (Exception)
                    {

                        throw new Exception("Veritabanı güncellenemedi.");
                    }
                }
                  
            }
            return host;
        }

    }
}

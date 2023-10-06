using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using Microsoft.AspNetCore.Builder;

namespace LibraryAPI.Core.Utilities.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
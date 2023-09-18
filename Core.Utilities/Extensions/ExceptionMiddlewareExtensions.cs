﻿using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.AspNetCore.Builder;

namespace Core.Utilities.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
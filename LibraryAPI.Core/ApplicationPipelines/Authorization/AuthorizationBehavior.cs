using Castle.DynamicProxy;
using Core.Utilities.IoC;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Core.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Core.ApplicationPipelines.Authorization
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse> , ISecuredRequest
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor) 
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<string>? roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            await Console.Out.WriteLineAsync(request.Roles[1]);

            TResponse response = await next();

            return response;








            //         private string[] _roles;
            //    private IHttpContextAccessor _httpContextAccessor;
            //    public SecuredOperation(string roles)
            //    {
            //        _roles = roles.Split(',');
            //        _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

            //    }

            //    protected override void OnBefore(IInvocation invocation)
            //    {
            //        var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            //        foreach (var role in _roles)
            //        {
            //            if (roleClaims.Contains(role))
            //            {
            //                return;
            //            }
            //        }
            //        throw new Exception(Messages.AuthorizationDenied);
            //    }
            //}


















        }
    }
}

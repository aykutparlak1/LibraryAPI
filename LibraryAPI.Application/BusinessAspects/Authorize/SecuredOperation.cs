using Castle.DynamicProxy;
using LibraryAPI.Application.Repositories.UserRepositories.UserOperationClaimRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Core.Utilities.Extensions;
using LibraryAPI.Core.Utilities.Interceptors;
using LibraryAPI.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryAPI.Core.Aspects.Autofac.Authorize
{
    public class SecuredOperation : MethodInterception
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserOperationClaimReadRepository _userOperationClaimReadRepository;
        private readonly string[] _roles;
        public SecuredOperation(string roles)
        {
            _roles=roles.Split(",");
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            _userOperationClaimReadRepository = ServiceTool.ServiceProvider.GetService<IUserOperationClaimReadRepository>();
        }


        protected override void OnBefore(IInvocation invocation)
        {
            int UId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.ClaimId());
            if (UId!=0)
            {
                foreach (var item in _roles)
                {
                    if( _userOperationClaimReadRepository.GetQuery(x => x.UserId == UId).Any(x => x.OperationClaim.Name == item))
                    {
                        return;
                    }
                }
            }
            throw new AuthorizationException("Yetkiniz yok");
        }
    }
}

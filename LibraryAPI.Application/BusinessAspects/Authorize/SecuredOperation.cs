using Castle.DynamicProxy;
using LibraryAPI.Application.Repositories.UserRepositories.UserOperationClaimRepository;
using LibraryAPI.Application.Services.ReadServices.UserReadService;
using LibraryAPI.Application.Services.WriteServices.UserWriteServices;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Core.Utilities.Extensions;
using LibraryAPI.Core.Utilities.Interceptors;
using LibraryAPI.Domain.Entities.UserEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Core.Aspects.Autofac.Authorize
{
    public class SecuredOperation : MethodInterception
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IUserOperationClaimReadService _userOperationClaimReadService;
        private readonly string _role;
        public SecuredOperation(string role, IHttpContextAccessor httpContextAccessor )
        {
            _role = role;
            //_userOperationClaimReadService = userOperationClaimReadService;
            _httpContextAccessor = httpContextAccessor;
        }


        protected override void OnBefore(IInvocation invocation)
        {
            if (_httpContextAccessor.HttpContext.User==null)
            {
                throw new AuthorizationException("Yetkiniz yok.");
            }
            int UId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.ClaimId());
            //var usroprclms = _userOperationClaimReadService;
            //if (!usroprclms.Result)
            //{
            //    throw new AuthorizationException("Yetkiniz yok.");
            //}
        }
    }
}

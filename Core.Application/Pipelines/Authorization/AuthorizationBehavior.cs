using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Extensions;
using LibraryAPI.Application.Interfaces;
using LibraryAPI.Application.Repositories.UserRepositories.UserOperationClaimRepositories;
using LibraryAPI.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Core.Pipelines.Authorization
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse> , ISecuredRequest
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserOperationClaimReadRepository _userOperationClaimReadRepository;
        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor, IUserOperationClaimReadRepository userOperationClaimReadRepository) 
        {
            _httpContextAccessor = httpContextAccessor;
            _userOperationClaimReadRepository = userOperationClaimReadRepository;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext.User.ClaimId().IsNullOrEmpty())
            {
                throw new AuthorizationException("Giriş yapınız.");
            }
            int UId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.ClaimId());
                var usroprclms = _userOperationClaimReadRepository.GetQuery(x => x.UserId == UId ,include: u => u.Include(u => u.OperationClaim))
                    .Select(u => new OperationClaim {Name = u.OperationClaim.Name }).AnyAsync(x=>x.Name == request.Roles);
                if (!usroprclms.Result)
                {
                    throw new AuthorizationException("Yetkiniz yok.");
                }
        TResponse response = await next();
        return response;
        }
    }
}

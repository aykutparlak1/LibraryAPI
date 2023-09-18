using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Extensions;
using LibraryAPI.Application.Interfaces;
using LibraryAPI.Application.Repositories.UserRepositories.UserOperationClaimRepositories;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepositories;
using LibraryAPI.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            List<string>? roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            int UId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.ClaimId());
            if (Enum.IsDefined(typeof(UserTypes), roleClaims))
            {
                foreach (var role in roleClaims)
                {
                    if (!request.Roles.Contains(role))
                    {
                        throw new AuthorizationException("Yetkiniz yok.");
                    }
                }
            }
            else
            {
                List<OperationClaim> userOperationClaims = _userOperationClaimReadRepository.GetAll(u => u.UserId == UId,
                include: u => u.Include(u => u.OperationClaim)).Select(u => new OperationClaim { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();
                foreach (var role in userOperationClaims)
                {
                    if (!request.Roles.Contains(role.Name))
                    {
                        throw new AuthorizationException("Yetkiniz yok.");
                    }
                }
            }

        TResponse response = await next();

        return response;
        }
    }
}

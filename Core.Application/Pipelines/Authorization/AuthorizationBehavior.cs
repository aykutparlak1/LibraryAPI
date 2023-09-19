using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Extensions;
using Core.Utilities.IoC;
using LibraryAPI.Application.Interfaces;
using LibraryAPI.Application.Repositories.UserRepositories.UserOperationClaimRepositories;
using LibraryAPI.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
            var roleClaim = _httpContextAccessor.HttpContext.User.ClaimRoles();
            int UId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.ClaimId());
            if (!request.Roles.Contains(roleClaim))
            {
                OperationClaim? usroprclms = _userOperationClaimReadRepository.GetQuery(x => x.UserId == UId ,include: u => u.Include(u => u.OperationClaim))
                    .Select(u => new OperationClaim { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).SingleOrDefault(x=>x.Name == request.Roles[0]);

                if (usroprclms==null)
                {
                    throw new AuthorizationException("Yetkiniz yok.");
                }
                //List<OperationClaim> userOperationClaims = _userOperationClaimReadRepository.GetAll(u => u.UserId == UId,include: u => u.Include(u => u.OperationClaim))
                //    .Select(u => new OperationClaim { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();
                //foreach (var role in userOperationClaims)
                //{
                //    if (!request.Roles.Contains(role.Name))
                //    {
                //        throw new AuthorizationException("Yetkiniz yok.");
                //    }
                //}
            }
        TResponse response = await next();
        return response;
        }
    }
}

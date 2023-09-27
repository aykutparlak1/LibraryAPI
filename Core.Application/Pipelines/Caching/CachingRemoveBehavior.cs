using Core.Utilities.Caching;
using LibraryAPI.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Caching
{
    public class CachingRemoveBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ICacheRemoveRequest
    {
        private readonly ICacheService _cacheService;

        public CachingRemoveBehavior(ICacheService cacheService)
        {
             _cacheService = cacheService;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var result = await _cacheService.GetAsync<TResponse>(request.CacheGroup,cancellationToken);
            if (result !=null)
            {
               await _cacheService.RemoveByGroupAsync(request.CacheGroup, cancellationToken);
            }
            TResponse response = await next();
            return response;
        }
    }
}

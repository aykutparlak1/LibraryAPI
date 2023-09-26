using Core.Utilities.Caching;
using LibraryAPI.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Core.Application.Pipelines.Caching
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ICachableRequest
    {
        private readonly ICacheService _cacheService;
        public CachingBehavior(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response;
            var result = await _cacheService.GetAsync<TResponse>(request.CacheKey, cancellationToken);
            if(result != null)
            {
                response = result;
            }
            else
            {
                response = (TResponse?)await _cacheService.Add(request.CacheKey, next, request.SlidingExpiration, cancellationToken);
            }
            if(request.CacheGroup != null)
            {
                _ = _cacheService.AddCacheKeyToGroup(request.CacheKey, request.CacheGroup, request.SlidingExpiration, cancellationToken);
            }
            return response;
        }
    }
}


using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fwk.template.api.common;

namespace fwk.template.api.common.jwt
{
    public class TokenManager : ITokenManager
    {
        readonly IDistributedCache _cache;
        readonly IHttpContextAccessor _httpContext;
        readonly IApiConfig _options;

        public TokenManager(IDistributedCache cache,
            IHttpContextAccessor httpContext
            //IApiConfig options
            )
        {
            _cache = cache;
            _httpContext = httpContext;
           _options = apiAppSettings.apiConfig;

        }

        public async Task<bool> IsCurrentActiveToken()
            => await IsActiveAsync(GetCurrentAsync());



        public async Task DesactivateCurrentAsynv()
        => await DesActiveAsync(GetCurrentAsync());

        /// <summary>
        /// obtener el token por medio de su clave
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<bool> IsActiveAsync(string token)
        => await _cache.GetStringAsync(GetKey(token)) == null;

        public async Task DesActiveAsync(string token)
          => await _cache.SetStringAsync(GetKey(token), //set ny value that makes sense as longs as it´s not an umpty or null value
            " ", new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_options.api_expireTime)
            });

        private static string GetKey(string token) => $"tokens:{token}:desactivated";

        private  string GetCurrentAsync() {

            var authHeader = _httpContext.HttpContext.Request.Headers["authorization"];

            return authHeader == StringValues.Empty ? string.Empty :
                        authHeader.Single().Split(" ").Last(); //Bearer token
        }

    }
}

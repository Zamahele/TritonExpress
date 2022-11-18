using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Service.Contract;

namespace TritonExpress.API.Service.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly IRepositoryIdentity<HttpResponseMessage> _context;
        private readonly ICacheService _cacheService;
        public TokenService(IRepositoryIdentity<HttpResponseMessage> repository, ICacheService cacheService)
        {
            _context = repository;
            _context.requestUrl = "GenerateToken";
            _cacheService = cacheService;
        }
        public string GetToken(string username)
        {
            var cacheData = _cacheService?.GetData<Token>("token");
            if (cacheData?.TokenCode != null)
            {
                _cacheService.RemoveData("token");
            }
            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
            var response = _context.GetToken(username);
            var getToke = response.Content.ReadAsAsync<Token>().Result;
            if (getToke != null)
            {
                _cacheService.SetData<Token>("token", getToke, expirationTime);
            }
            return getToke.TokenCode;
        }
    }
}

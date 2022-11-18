using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TritonExpress.API.Domain.Entities;
using TritonExpress.API.Persistence;
using TritonExpress.API.Service.Contract;

namespace TritonExpress.API.Service.Features.TokenFeatures.Query
{
    public class GetTokenQuery : IRequest<HttpResponseMessage>
    {

        public string UserName { get; set; }
        public class GetTokenQueryHannder : IRequestHandler<GetTokenQuery, HttpResponseMessage>
        {
            private readonly IRepository<Token> context;
            public GetTokenQueryHannder(IRepository<Token> context)
            {
                this.context = context;
                this.context.requestUrl = "Generate";
            }
            public async Task<HttpResponseMessage> Handle(GetTokenQuery request, CancellationToken cancellationToken)
            {
                return await Task.Run(()=> context.GetToken(request.UserName));
            }
        }

    }
}

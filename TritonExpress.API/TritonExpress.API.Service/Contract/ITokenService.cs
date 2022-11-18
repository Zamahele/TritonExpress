using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TritonExpress.API.Service.Contract
{
    public interface ITokenService
    {
        string GetToken(string username);
    }
}

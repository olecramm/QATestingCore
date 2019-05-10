using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace QATestingCore.IntegratedTests.Authentications
{
    public interface IJWTAuthentication
    {
        string GetOauthAuthentication(UriBuilder uriBuilder, JObject paramsObj);
    }
}
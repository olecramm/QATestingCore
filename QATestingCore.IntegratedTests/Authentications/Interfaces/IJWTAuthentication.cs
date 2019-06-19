using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace QATestingCore.IntegratedTests.Authentications
{
    /// <summary>
    /// Create the UriBuilder object in memory
    /// </summary>
    public interface IJWTAuthentication
    {
        /// <summary>
        /// Generate oauth token through an authentication server asynchronously
        /// </summary>
        /// <param name="uriBuilder">Represents an object that contains client and request informations</param>
        /// <param name="paramsObj">Represents an objects with the parameters to be sent wrapped into the request</param>
        /// <returns>Returns a token sent for the oauth authentication server</returns>
        string GetOauthAuthentication(UriBuilder uriBuilder, JObject paramsObj);
    }
}
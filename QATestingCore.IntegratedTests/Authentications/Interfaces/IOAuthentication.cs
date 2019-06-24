using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QATestingCore.IntegratedTests.Authentications
{
    /// <summary>
    /// Create the UriBuilder object in memory
    /// </summary>
    public interface IOAuthentication
    {
        /// <summary>
        /// Generate oauth token through an authentication server asynchronously
        /// </summary>
        /// <param name="uriBuilder">Represents an object that contains client and request informations</param>
        /// <param name="paramsObj">Represents an objects with the parameters to be sent wrapped into the request</param>
        /// <returns>Returns a token sent for the oauth authentication server</returns>
        IList<HeaderAuthParams> BearerAuthentication(UriBuilder uriBuilder, JObject paramsObj);
    }
}
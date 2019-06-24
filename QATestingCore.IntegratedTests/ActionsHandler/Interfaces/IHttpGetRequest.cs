using System;
using System.Collections.Generic;
using QATestingCore.IntegratedTests.Authentications;
using RestSharp;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    /// <summary>
    /// Contains method to beget call to the endpoint as Http action GET
    /// </summary>
    public interface IHttpGetRequest
    {
        /// <summary>
        /// Create Get request and execute the call to an endpoint
        /// </summary>
        /// <param name="uriBuilder">Represents an object that contains client and request informations</param>
        /// <param name="method">Represents an objects with the parameters to be sent wrapped into the request</param>
        /// <param name="headerAuthParams">Represents a list of header parameters to be wrapped into the request call. It is considered null value when it were omitted</param>
        /// <returns>Return an IRestResponse object</returns>
        IRestResponse MakeGetRequest(UriBuilder uriBuilder,
                                     HttpMethod method = HttpMethod.GET,
                                     IList<HeaderAuthParams> headerAuthParams = null);
    }
}
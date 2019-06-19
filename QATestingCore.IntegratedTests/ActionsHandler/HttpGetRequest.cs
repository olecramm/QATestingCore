using RestSharp;
using System;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    /// <summary>
    /// Contains method to beget call to the endpoint as Http action GET
    /// </summary>
    public class HttpGetRequest : HttpBaseRequest, IHttpGetRequest
    {
        /// <summary>
        /// Create Get request and execute the call to an endpoint
        /// </summary>
        /// <param name="uriBuilder">Represents an object that contains client and request informations</param>
        /// <param name="method">Represents an objects with the parameters to be sent wrapped into the request</param>
        /// <param name="token">Represents the key informed. Obs.:It is considered null value when it were omitted</param>
        /// <returns>Return an IRestResponse object</returns>
        public IRestResponse MakeGetRequest(UriBuilder uriBuilder,
                                            HttpMethod method = HttpMethod.GET,
                                            string token = null)
        {
            var baseUrl = AssembleBaseUrl(uriBuilder);

            Arrange(baseUrl, uriBuilder.Uri.LocalPath, method, DataFormat.Json, null, token);

            return Act();
        }
    }
}

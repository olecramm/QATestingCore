using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    public class HttpPostRequest : HttpBaseRequest, IHttpPostRequest
    {
        /// <summary>
        /// Create Post request and execute the call to an endpoint
        /// </summary>
        /// <param name="uriBuilder">Represents an object that contains client and request informations</param>
        /// <param name="paramsBody">Represents an objects with the parameters to be sent wrapped into the request</param>
        /// <param name="token">Represents the key informed. Obs.:It is considered null value when it were omitted</param>
        /// <returns>Return an IRestResponse object</returns>
        public IRestResponse MakePostRequet(UriBuilder uriBuilder,
                                            JObject paramsBody,
                                            string token = null)
        {  
            var baseUrl = AssembleBaseUrl(uriBuilder);

            Arrange(baseUrl,
                    uriBuilder.Uri.LocalPath,
                    Method.POST, 
                    DataFormat.Json,
                    paramsBody,
                    token);

            return Act();
        }
    }
}

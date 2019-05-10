using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    public class HttpPutRequest : HttpBaseRequest, IHttpPutRequest
    {
        public IRestResponse MakePutRequest(UriBuilder uriBuilder,
                                            JObject paramsBody,
                                            string token = null)
        {
            var baseUrl = AssembleBaseUrl(uriBuilder);

            Arrange(baseUrl,
            uriBuilder.Uri.LocalPath,
            Method.PUT,
            DataFormat.Json,
            paramsBody,
            token);

            return Act();
        }
    }
}

using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    public class HttpGetRequest : HttpBaseRequest, IHttpGetRequest
    {

        public IRestResponse MakeGetRequest(UriBuilder uriBuilder, 
                                            Method method = Method.GET, 
                                            string token = null)
        {
            var baseUrl = AssembleBaseUrl(uriBuilder);

            Arrange(baseUrl, uriBuilder.Uri.LocalPath, method, DataFormat.Json, null, token);

            return Act();
        }
    }
}

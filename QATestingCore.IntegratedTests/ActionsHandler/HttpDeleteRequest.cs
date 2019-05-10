using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    public class HttpDelRequest : HttpBaseRequest, IHttpDelRequest
    {
        public IRestResponse MakeDeleteRequest(UriBuilder uriBuilder,
                                               Method method = Method.DELETE,
                                               string token = null)
        {
            var baseUrl = AssembleBaseUrl(uriBuilder);

            Arrange(baseUrl,
                    uriBuilder.Uri.LocalPath,
                    method,
                    DataFormat.Json,
                    null,
                    token);

            return Act();
        }

    }
}

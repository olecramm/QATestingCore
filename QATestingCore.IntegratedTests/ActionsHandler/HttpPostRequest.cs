using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    public class HttpPostRequest : HttpBaseRequest, IHttpPostRequest
    {
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

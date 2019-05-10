using System;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    public interface IHttpPostRequest
    {
        IRestResponse MakePostRequet(UriBuilder uriBuilder, 
                                     JObject paramsBody, 
                                     string token = null);
    }
}
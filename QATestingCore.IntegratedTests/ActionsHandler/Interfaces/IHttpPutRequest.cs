using System;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    public interface IHttpPutRequest
    {
        IRestResponse MakePutRequest(UriBuilder uriBuilder, 
                                     JObject paramsBody, 
                                     string token = null);
    }
}
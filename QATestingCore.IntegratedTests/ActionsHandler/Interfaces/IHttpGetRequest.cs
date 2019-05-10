using System;
using RestSharp;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    public interface IHttpGetRequest
    {
        IRestResponse MakeGetRequest(UriBuilder uri, Method method = Method.GET, string token = null);
    }
}
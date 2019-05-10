using System;
using RestSharp;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    public interface IHttpDelRequest
    {
        IRestResponse MakeDeleteRequest(UriBuilder uriBuilder, Method method = Method.DELETE, string token = null);
    }
}
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    public abstract class HttpBaseRequest
    {
        private RestClient RestClient;
        private RestRequest RestRequest;

        protected void Arrange(string baseUrl,
                                        string resourcePath,
                                        Method method,                                        
                                        DataFormat dataFormat,
                                        JObject paramsBody = null,
                                        string token = null)
        {
            RestClient = new RestClient(baseUrl);

            RestRequest = new RestRequest(resourcePath, method, dataFormat);

            if (paramsBody != null)
            {
                RestRequest.AddJsonBody(paramsBody);
            }

            if (token != null)
            {
                RestRequest.AddHeader("Authentication", string.Format("Bearer {0}", token));
            }
        }

        protected IRestResponse Act()
        {
            return RestClient.Execute(RestRequest);
        }

        protected async Task<IRestResponse> ActAsync()
        {
            return await RestClient.ExecuteTaskAsync(RestRequest);
        }

        protected string AssembleBaseUrl(UriBuilder uriBuilder)
        {
            string baseUrl;

            return baseUrl = $"{uriBuilder.Scheme}://{uriBuilder.Uri.Authority}";
        }
    }
}

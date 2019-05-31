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
        /// <summary>
        /// RestClient object of RestSharp library
        /// </summary>
        private RestClient RestClient;

        /// <summary>
        /// restRequest object of RestSharp library
        /// </summary>
        private RestRequest RestRequest;

        /// <summary>
        /// Arrange the request to call the endpoint
        /// </summary>
        /// <param name="baseUrl">Represents the host endpoint URL</param>
        /// <param name="resourcePath">Represents the path of the resource inside the endpoint server</param>
        /// <param name="method">Represents the http verb that the call will execute on the endpoint</param>
        /// <param name="dataFormat">Represents the data type expected as response by the endipoint json or xml</param>
        /// <param name="paramsBody">Represents an objects with the parameters to be sent wrapped into the request. Obs.:It is considered null value when it were omitted</param>
        /// <param name="token">Represents the key informed. Obs.:It is considered null value when it were omitted</param>
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

        /// <summary>
        /// Execute the client synchronously to the configured endpoint with the request informations
        /// </summary>
        /// <returns></returns>
        protected IRestResponse Act()
        {
            return RestClient.Execute(RestRequest);
        }

        /// <summary>
        /// Execute asynchronously the client to the configured endpoint with the request informations
        /// </summary>
        /// <returns></returns>
        protected async Task<IRestResponse> ActAsync()
        {
            return await RestClient.ExecuteTaskAsync(RestRequest);
        }

        /// <summary>
        /// Assemble the Url properly to be used in the client object
        /// </summary>
        /// <param name="uriBuilder"></param>
        /// <returns></returns>
        protected string AssembleBaseUrl(UriBuilder uriBuilder)
        {
            string baseUrl;

            return baseUrl = $"{uriBuilder.Scheme}://{uriBuilder.Uri.Authority}";
        }
    }
}

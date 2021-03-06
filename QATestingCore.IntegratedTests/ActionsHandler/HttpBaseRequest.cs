﻿using Newtonsoft.Json.Linq;
using QATestingCore.IntegratedTests.Authentications;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    /// <summary>
    /// Contains methods that assembles client and request to call endpoints
    /// </summary>
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
        /// <param name="EnumMethod">Represents the http verb that the call will execute on the endpoint</param>
        /// <param name="dataFormat">Represents the data type expected as response by the endipoint json or xml</param>
        /// <param name="paramsBody">Represents an objects with the parameters to be sent wrapped into the request. Obs.:It is considered null value when it were omitted</param>
        /// <param name="headerAuthParams">Represents a list of header parameters to be wrapped into the request call. Obs.:It is considered null value when it were omitted</param>
        protected void Arrange(string baseUrl,
                               string resourcePath,
                               HttpMethod EnumMethod,
                               DataFormat dataFormat,
                               JObject paramsBody = null,
                               IList<HeaderAuthParams> headerAuthParams = null)
        {
            RestClient = new RestClient(baseUrl);

            RestRequest = new RestRequest(resourcePath, (Method)EnumMethod, dataFormat);

            if (paramsBody != null)
            {
                RestRequest.AddJsonBody(paramsBody);
            }

            if (headerAuthParams != null)
            {
                foreach (var item in headerAuthParams)
                {
                    RestRequest.AddHeader(item.HeaderName, item.HearderValue);
                }
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

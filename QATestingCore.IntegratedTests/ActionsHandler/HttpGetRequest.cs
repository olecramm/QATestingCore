﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    public class HttpGetRequest : HttpBaseRequest, IHttpGetRequest
    {
        /// <summary>
        /// Create Get request and execute the call to an endpoint
        /// </summary>
        /// <param name="uriBuilder">Represents an object that contains client and request informations</param>
        /// <param name="method">Represents an objects with the parameters to be sent wrapped into the request</param>
        /// <param name="token">Represents the key informed. Obs.:It is considered null value when it were omitted</param>
        /// <returns>Return an IRestResponse object</returns>
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

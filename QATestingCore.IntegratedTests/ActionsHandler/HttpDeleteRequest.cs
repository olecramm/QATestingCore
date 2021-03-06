﻿using QATestingCore.IntegratedTests.Authentications;
using RestSharp;
using System;
using System.Collections.Generic;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    /// <summary>
    /// Contains method to beget call to the endpoint as Http action DEL
    /// </summary>
    public class HttpDelRequest : HttpBaseRequest, IHttpDelRequest
    {
        /// <summary>
        /// Create Delete request and execute the call to an endpoint
        /// </summary>
        /// <param name="uriBuilder">Represents an object that contains client and request informations</param>
        /// <param name="method">Represents an objects with the parameters to be sent wrapped into the request</param>
        /// <param name="headerAuthParams">Represents a list of header parameters to be wrapped into the request call. Obs.:It is considered null value when it were omitted</param>
        /// <returns>Return an IRestResponse object</returns>
        public IRestResponse MakeDeleteRequest(UriBuilder uriBuilder,
                                               HttpMethod method = HttpMethod.DELETE,
                                               IList<HeaderAuthParams> headerAuthParams = null)
        {
            var baseUrl = AssembleBaseUrl(uriBuilder);

            Arrange(baseUrl,
                    uriBuilder.Uri.LocalPath,
                    method,
                    DataFormat.Json,
                    null,
                    headerAuthParams);

            return Act();
        }

    }
}

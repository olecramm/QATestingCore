﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using QATestingCore.IntegratedTests.Authentications;
using RestSharp;

namespace QATestingCore.IntegratedTests.ActionsHandler
{
    /// <summary>
    /// Contains method to beget call to the endpoint as Http action POST
    /// </summary>
    public interface IHttpPostRequest
    {
        /// <summary>
        /// Create Post request and execute the call to an endpoint
        /// </summary>
        /// <param name="uriBuilder">Represents an object that contains client and request informations</param>
        /// <param name="paramsBody">Represents an objects with the parameters to be sent wrapped into the request</param>
        /// <param name="headerAuthParams">Represents a list of header parameters to be wrapped into the request call. It is considered null value when it were omitted</param>
        /// <returns>Return an IRestResponse object</returns>
        IRestResponse MakePostRequet(UriBuilder uriBuilder, 
                                     JObject paramsBody,
                                     IList<HeaderAuthParams> headerAuthParams = null);
    }
}
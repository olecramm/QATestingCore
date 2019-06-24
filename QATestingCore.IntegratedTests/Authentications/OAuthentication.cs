using Newtonsoft.Json.Linq;
using QATestingCore.IntegratedTests.ActionsHandler;
using RestSharp;
using System;
using System.Collections.Generic;

namespace QATestingCore.IntegratedTests.Authentications
{
    /// <summary>
    /// Contains methods to beget token authentication in diferent types
    /// </summary>
    public class OAuthentication : HttpBaseRequest, IOAuthentication
    {
        private UriBuilder uriBuilder;


        /// <summary>
        /// Represents a list of header parameters
        /// </summary>
        IList<HeaderAuthParams> headerAuthParams;

        /// <summary>
        /// Create the UriBuilder object in memory
        /// </summary>
        public OAuthentication()
        {
            uriBuilder = new UriBuilder();
            headerAuthParams = new List<HeaderAuthParams>();
        }

        /// <summary>
        /// Generate oauth token as bearer type through an authentication server asynchronously
        /// </summary>
        /// <param name="uriBuilder">Represents an object that contains client and request informations</param>
        /// <param name="paramsObj">Represents an objects with the parameters to be sent wrapped into the request</param>
        /// <returns>Returns a list of parameters as Bearer type e.g.:"Bearer[tokenjwtkey"]</returns>
        public IList<HeaderAuthParams> BearerAuthentication(UriBuilder uriBuilder, JObject paramsObj)
        {
            var baseUrl = AssembleBaseUrl(uriBuilder);

            Arrange(baseUrl,
                    uriBuilder.Uri.LocalPath,
                    HttpMethod.POST,
                    DataFormat.Json,
                    paramsObj);

            var response = ActAsync().GetAwaiter().GetResult();

            var accessToken = JObject.Parse(response.Content);

            headerAuthParams.Add(new HeaderAuthParams("Authentication",string.Format("Bearer {0}", accessToken.GetValue("access_token").ToString())));
            headerAuthParams.Add(new HeaderAuthParams("Authentication2", string.Format("Bearer {0}", accessToken.GetValue("access_token").ToString())));
            headerAuthParams.Add(new HeaderAuthParams(null, string.Format("Bearer {0}", accessToken.GetValue("access_token").ToString())));

            return headerAuthParams;
        }
    }
}

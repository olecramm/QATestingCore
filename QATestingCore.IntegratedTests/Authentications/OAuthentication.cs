using Newtonsoft.Json.Linq;
using QATestingCore.IntegratedTests.ActionsHandler;
using RestSharp;
using System;

namespace QATestingCore.IntegratedTests.Authentications
{
    /// <summary>
    /// Contains methods to beget token authentication in diferent types
    /// </summary>
    public class OAuthentication : HttpBaseRequest, IOAuthentication
    {
        private UriBuilder uriBuilder;

        /// <summary>
        /// Create the UriBuilder object in memory
        /// </summary>
        public OAuthentication()
        {
            uriBuilder = new UriBuilder();
        }

        /// <summary>
        /// Generate oauth token as bearer type through an authentication server asynchronously
        /// </summary>
        /// <param name="uriBuilder">Represents an object that contains client and request informations</param>
        /// <param name="paramsObj">Represents an objects with the parameters to be sent wrapped into the request</param>
        /// <returns>Returns an oauth token as Bearer type e.g.:"Bearer[tokenjwtkey"]</returns>
        public HeaderAuthParams BearerAuthentication(UriBuilder uriBuilder, JObject paramsObj)
        {
            var baseUrl = AssembleBaseUrl(uriBuilder);

            Arrange(baseUrl,
                    uriBuilder.Uri.LocalPath,
                    HttpMethod.POST,
                    DataFormat.Json,
                    paramsObj);

            var response = ActAsync().GetAwaiter().GetResult();

            var accessToken = JObject.Parse(response.Content);

            HeaderAuthParams headerAuthParams = new HeaderAuthParams() {
                HeaderName = "Authentication",
                HearderValue = string.Format("Bearer {0}", accessToken.GetValue("access_token").ToString())
            };

            return headerAuthParams;
        }
    }
}
